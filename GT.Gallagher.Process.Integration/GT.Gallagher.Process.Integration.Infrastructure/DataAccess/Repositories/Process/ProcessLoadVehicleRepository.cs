using AutoMapper;
using CsvHelper.Configuration;
using CsvHelper;
using GT.Gallagher.Process.Integration.Application.Repository.Process;
using GT.Gallagher.Process.Integration.Domain.Common;
using GT.Gallagher.Process.Integration.Domain.Process.LoadVehicle;
using GT.Gallagher.Process.Integration.Infrastructure.DataAccess.Entities;
using GT.Gallagher.Process.Integration.Infrastructure.DataAccess.Entities.Map.Process;
using GT.Gallagher.Process.Integration.Infrastructure.Helper;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Renci.SshNet;
using System.Data;
using System.Globalization;
using System.Text;

using EntCommon = GT.Gallagher.Process.Integration.Infrastructure.DataAccess.Entities.Common;
using Ent = GT.Gallagher.Process.Integration.Infrastructure.DataAccess.Entities.Process.LoadVehicle;

namespace GT.Gallagher.Process.Integration.Infrastructure.DataAccess.Repositories.Process;

public class ProcessLoadVehicleRepository : IProcessLoadVehicleRepository
{
    private readonly IMapper _mapper;

    public ProcessLoadVehicleRepository(IMapper mapper) => _mapper = mapper;

    public int GenerateProcess(Guid code, Guid scheduledProcess, int userId)
    {
        var parameters = new List<SqlParameter>()
        {
            new() { SqlDbType = SqlDbType.Int, ParameterName = "ReturnValue", Direction = ParameterDirection.Output },
            new() { SqlDbType = SqlDbType.UniqueIdentifier, ParameterName = "@Code", Direction = ParameterDirection.Input, Value = code },
            new() { SqlDbType = SqlDbType.UniqueIdentifier, ParameterName = "@ScheduledProcess", Direction = ParameterDirection.Input, Value = scheduledProcess },
            new() { SqlDbType = SqlDbType.Int, ParameterName = "@UserId", Direction = ParameterDirection.Input, Value = userId }
        };

        new Context().Database.ExecuteSqlRaw(@"exec @returnValue = SWP_Process_Generate @Code, @ScheduledProcess, @UserId", parameters.ToArray());

        return (int)parameters[0].Value;
    }

    public int SaveProcessMaster(Guid masterCode, int userId, Guid processCode, Guid uniqueName, string fileName, string ext, List<ProcessLoadVehicleDetails> processLoadDetails, int quantityRows)
    {
        List<EntCommon.MasterDetailsInput> masterDetails = new();

        foreach (var singleRow in processLoadDetails)
        {
            masterDetails.Add(new EntCommon.MasterDetailsInput(singleRow.RowNumber,
                _mapper.Map<Ent.ProcessLoadVehicle>(singleRow.ProcessLoadVehicle),
                _mapper.Map<List<ProblemDetail>>(singleRow.Details)));
        }

        var parameters = new List<SqlParameter>()
        {
            new() { SqlDbType = SqlDbType.Int, ParameterName = "ReturnValue", Direction = ParameterDirection.Output },
            new() { SqlDbType = SqlDbType.UniqueIdentifier, ParameterName = "@MasterCode", Direction = ParameterDirection.Input, Value = masterCode },
            new() { SqlDbType = SqlDbType.Int, ParameterName = "@UserId", Direction = ParameterDirection.Input, Value = userId },
            new() { SqlDbType = SqlDbType.UniqueIdentifier, ParameterName = "@ProcessCode", Direction = ParameterDirection.Input, Value = processCode },
            new() { SqlDbType = SqlDbType.UniqueIdentifier, ParameterName = "@UniqueName", Direction = ParameterDirection.Input, Value = uniqueName },
            new() { SqlDbType = SqlDbType.VarChar, ParameterName = "@Name", Direction = ParameterDirection.Input, Value = fileName },
            new() { SqlDbType = SqlDbType.VarChar, ParameterName = "@Extension", Direction = ParameterDirection.Input, Value = ext },
            new() { SqlDbType = SqlDbType.Structured, ParameterName = "@MasterDetails", TypeName = "dbo.MasterDetails", Value = Util.ListToDataTable(masterDetails) },
            new() { SqlDbType = SqlDbType.Int, ParameterName = "@QuantityRows", Direction = ParameterDirection.Input, Value = quantityRows },
        };

        new Context().Database.ExecuteSqlRaw(@"exec @returnValue = SWP_Plot_SaveProcess_Load @MasterCode, @UserId, @ProcessCode, @UniqueName, @Name, @Extension, @MasterDetails, @QuantityRows ", parameters.ToArray());

        return (int) parameters[0].Value;
    }

    public List<(int, string)> ReadContentFile(byte[] bytes)
    {
        var listLines = new List<(int, string)>();
        int rowNumber = 0;
        string line;

        using (MemoryStream memoryStream = new(bytes))
        {
            using (StreamReader streamReader = new(memoryStream, Encoding.UTF8))
            {
                while ((line = streamReader.ReadLine()) != null)
                {
                    listLines.Add((rowNumber++, line));
                }
            }
        }
        return listLines;
    }

    public List<ProcessLoadVehicleContent> BuildContentFile(List<(int, string)> lines)
    {
        List<ProcessLoadVehicleContent> result = new();
        int rowNumber = 2;

        using (var reader = new StringReader(string.Join('\n', lines.Select(item => item.Item2).ToList())))
        {
            var config = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                Delimiter = ";",
                HasHeaderRecord = false,
                MissingFieldFound = null
            };
            using (var csv = new CsvReader(reader, config))
            {
                csv.Context.RegisterClassMap<ProcessLoadVehicleMap>();

                var records = csv.GetRecords<Ent.ProcessLoadVehicle>().ToList();
                var lista = _mapper.Map<List<ProcessLoadVehicle>>(records);
                    lista.ForEach(item =>
                    {
                        result.Add(new ProcessLoadVehicleContent(rowNumber++, item));
                    });
            }
        }
        return result;
    }

    public List<ProcessLoadVehicleFeedBack> GetMasterDetailsFeedBack(Guid masterCode)
    {
        var parameters = new List<SqlParameter>()
        {
            new() { SqlDbType = SqlDbType.UniqueIdentifier, ParameterName = "@MasterCode", Direction = ParameterDirection.Input, Value = masterCode }
        };

        var result = new Context().Set<Ent.ProcessLoadVehicleFeedBack>()
            .FromSqlRaw(@"exec SWP_Plot_Get_MasterDetailsVehicle @MasterCode", parameters.ToArray())
            .ToList();

        return _mapper.Map<List<ProcessLoadVehicleFeedBack>>(result);
    }

    public int LoadDataToProcess(Guid masterCode)
    {
        var parameters = new List<SqlParameter>()
        {
            new() { SqlDbType = SqlDbType.Int, ParameterName = "ReturnValue", Direction = ParameterDirection.Output },
            new() { SqlDbType = SqlDbType.UniqueIdentifier, ParameterName = "@MasterCode", Direction = ParameterDirection.Input, Value = masterCode }
        };

        new Context().Database.ExecuteSqlRaw(@"exec @returnValue = SWP_Plot_ProcessLoadVehicle @MasterCode", parameters.ToArray());

        return (int) parameters[0].Value;
    }

    public int ProcessVehiclePlotData(Guid masterCode)
    {
        var parameters = new List<SqlParameter>()
        {
            new() { SqlDbType = SqlDbType.Int, ParameterName = "ReturnValue", Direction = ParameterDirection.Output },
            new() { SqlDbType = SqlDbType.UniqueIdentifier, ParameterName = "@MasterCode", Direction = ParameterDirection.Input, Value = masterCode }
        };

        new Context().Database.ExecuteSqlRaw(@"exec @returnValue = SWP_Plot_RunProcess_Vehicle @MasterCode", parameters.ToArray());

        return (int) parameters[0].Value;
    }

    public int EndProcessMaster(Guid masterCode, string feedback)
    {
        var parameters = new List<SqlParameter>()
        {
            new() { SqlDbType = SqlDbType.Int, ParameterName = "ReturnValue", Direction = ParameterDirection.Output },
            new() { SqlDbType = SqlDbType.UniqueIdentifier, ParameterName = "@MasterCode", Direction = ParameterDirection.Input, Value = masterCode },
            new() { SqlDbType = SqlDbType.VarChar, ParameterName = "@FeedBack", Direction = ParameterDirection.Input, Value = feedback }
        };

        new Context().Database.ExecuteSqlRaw(@"exec @returnValue = SWP_Plot_EndProcess_Load @MasterCode, @FeedBack", parameters.ToArray());

        return (int) parameters[0].Value;
    }

    public byte[] GenerateExcelToAttach(List<ProcessLoadVehicleFeedBack> masterDetailsFeedBack)
        => Util.GenerateExcel(masterDetailsFeedBack, "Details");


    public void PutSftpFilesHistory(RepositoryServer repository, string fileName, byte[] filebytes)
    {
        string directoryOutput = $"{DateTime.Now.ToString("yyyyMMdd")}/Output/";
        string directorySftpOutput = $"{repository.Root}/{directoryOutput}";
        string directorySaveOutput = $"{Environment.GetEnvironmentVariable("CUSTOM_FOLDER_ROUTE")}/{directoryOutput}";

        using (FileStream fileStream = new FileStream(Path.Combine(directorySaveOutput, fileName), FileMode.Create, FileAccess.Write))
        {
            fileStream.Write(filebytes, 0, filebytes.Length);
        }

        using (var client = new SftpClient(repository.Server, repository.User, repository.Password))
        {
            client.Connect();

            if (!client.Exists(directorySftpOutput))
                client.CreateDirectory(directorySftpOutput);

            using (var ms = new MemoryStream(filebytes))
            {
                client.ChangeDirectory(directorySftpOutput);
                client.UploadFile(ms, fileName);
            }
            client.Disconnect();
        }
    }

}
