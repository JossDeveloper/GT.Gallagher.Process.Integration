using AutoMapper;
using GT.Gallagher.Process.Integration.Application.Repository.Common;
using GT.Gallagher.Process.Integration.Domain.Common;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Data;

using Ent = GT.Gallagher.Process.Integration.Infrastructure.DataAccess.Entities.Common;

namespace GT.Gallagher.Process.Integration.Infrastructure.DataAccess.Repositories.Common;

public class CommonRepository : ICommonRepository
{
    private readonly IMapper _mapper;

    public CommonRepository(IMapper mapper) => _mapper = mapper;

    public ScheduledProcesses GetScheduledProcesses(Guid code, Int16 process)
    {
        var parameters = new List<SqlParameter>()
        {
            new() { SqlDbType = SqlDbType.UniqueIdentifier, ParameterName = "@Code", Direction = ParameterDirection.Input, Value = code },
            new() { SqlDbType = SqlDbType.Int, ParameterName = "@ProcessTypeId", Direction = ParameterDirection.Input, Value = process }
        };

        var result = new Context().Set<Ent.ScheduledProcesses>()
            .FromSqlRaw(@"exec SW_Get_Scheduled_Processes @Code, @ProcessTypeId", parameters.ToArray())
            .ToList().FirstOrDefault();

        return _mapper.Map<ScheduledProcesses>(result);
    }

    public RepositoryServer GetRepositorySftp(Guid? masterCode)
    {
        var parameters = new List<SqlParameter>()
        {
            new() { SqlDbType = SqlDbType.UniqueIdentifier, ParameterName = "@MasterCode", Direction = ParameterDirection.Input, Value = masterCode }
        };

        var result = new Context().Set<Ent.RepositoryServer>()
            .FromSqlRaw(@"exec SW_Get_Repository @MasterCode", parameters.ToArray())
            .ToList().FirstOrDefault();

        return _mapper.Map<RepositoryServer>(result);
    }

    public List<MasterDetailsOutput> GetMasterDetails(Guid masterCode)
    {
        var parameters = new List<SqlParameter>()
        {
            new() { SqlDbType = SqlDbType.UniqueIdentifier, ParameterName = "@MasterCode", Direction = ParameterDirection.Input, Value = masterCode }
        };

        var result = new Context().Set<Ent.MasterDetailsOutput>()
            .FromSqlRaw(@"exec SW_Get_MasterDetails @MasterCode", parameters.ToArray())
            .ToList();
        return _mapper.Map<List<MasterDetailsOutput>>(result);
    }
}
