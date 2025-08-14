using AutoMapper;
using GT.Gallagher.Process.Integration.Application.Repository.Recurrent;
using GT.Gallagher.Process.Integration.Domain.Common;
using GT.Gallagher.Process.Integration.Domain.Gallagher.Process;
using GT.Gallagher.Process.Integration.Domain.TPAService.Base;
using GT.Gallagher.Process.Integration.Infrastructure.Helper;
using Renci.SshNet;
using RestSharp;

using InfraProcess = GT.Gallagher.Process.Integration.Infrastructure.DataAccess.Entities.Gallagher.Process;
using InfraService = GT.Gallagher.Process.Integration.Infrastructure.DataAccess.Entities.TPAService;

namespace GT.Gallagher.Process.Integration.Infrastructure.DataAccess.Repositories.Recurrent.ProcessPlot;

public class RecurrentPlotRepository : IRecurrentPlotRepository
{
    private readonly IMapper _mapper;
    private readonly static string DirectoryToSave = Environment.GetEnvironmentVariable("CUSTOM_FOLDER_ROUTE");

    public RecurrentPlotRepository(IMapper mapper) => _mapper = mapper;

    public int CreateDirectoryToSaveFiles()
    {
        try
        {
            var directory = $"{DirectoryToSave}/{DateTime.Now.ToString("yyyyMMdd")}/";

            if (!Directory.Exists(DirectoryToSave))
                Directory.CreateDirectory(DirectoryToSave);
            if (!Directory.Exists(directory))
                Directory.CreateDirectory(directory);
            if (!Directory.Exists($"{directory}/Input"))
                Directory.CreateDirectory($"{directory}/Input");
            if (!Directory.Exists($"{directory}/Output"))
                Directory.CreateDirectory($"{directory}/Output");

            return 1;
        }
        catch (Exception)
        {
            return -1;
        }
    }

    public List<SftpFile> GetSftpFiles(RepositoryServer repository, string plotName)
    {
        List<SftpFile> sftpFiles = new();

        string directoryInput = $"{DateTime.Now.ToString("yyyyMMdd")}/Input/";
        string directorySftpInput = $"{repository.Root}/{directoryInput}";
        string directorySaveInput = $"{DirectoryToSave}/{directoryInput}";

        using (var client = new SftpClient(repository.Server, repository.User, repository.Password))
        {
            client.Connect();

            if (client.Exists(directorySftpInput))
            {
                var listFiles = client.ListDirectory(directorySftpInput);

                foreach (var remoteFile in listFiles.Where(s => s.Name.StartsWith(plotName) && Path.GetExtension(s.Name).ToLower() == ".csv"))
                {
                    var sftpFile = new SftpFile(remoteFile.Name);
                    var localFilePath = Path.Combine(directorySaveInput, remoteFile.Name);
                    using var fileSt = File.Create(localFilePath);
                    client.DownloadFile(remoteFile.FullName, fileSt);
                    client.DeleteFile(remoteFile.FullName);
                    sftpFiles.Add(sftpFile);
                }
            }
            client.Disconnect();
        };
        return sftpFiles;
    }

    public void PutSftpFilesHistory(RepositoryServer repository, string customRoot, List<SftpFile> sftpFiles)
    {
        string directorySaveInput = $"{DirectoryToSave}/{DateTime.Now.ToString("yyyyMMdd")}/Input/";

        using (var client = new SftpClient(repository.Server, repository.User, repository.Password))
        {
            client.Connect();

            foreach (var item in sftpFiles)
            {
                var localFilePath = Path.Combine(directorySaveInput, item.Name);
                using var fileSt = new FileStream(localFilePath, FileMode.Open);
                client.UploadFile(fileSt, Path.Combine(customRoot, $"{item.UniqueName}{item.Extension}"), true);
            }
            client.Disconnect();
        };
    }

    public (ServiceProcessLoadResponse?, BadResponse) SendToProcess(int userId, SftpFile sftpFile, string endpoint, string token)
    {
        string urlService = Environment.GetEnvironmentVariable("GT_GALLAGHER_URL");
        string timeoutService = Environment.GetEnvironmentVariable("GT_GALLAGHER_EXPIRATION_TIME");
        string directorySaveInput = $"{DirectoryToSave}/{DateTime.Now.ToString("yyyyMMdd")}/Input/";

        var request = UseService.MountRequestFormData(endpoint, Method.Post);
            request.AddHeader("Authorization", $"Bearer {token}");
            request.AddParameter("UserId", userId);
            request.AddParameter("ProcessCode", sftpFile.ProcessCode);
            request.AddParameter("UniqueName", sftpFile.UniqueName);
            request.AddFile("File", $"{directorySaveInput}/{sftpFile.Name}", "text/csv");

        var (successResponse, badResponse) = UseService.GetTpaResponseAsync<InfraProcess.ServiceProcessLoadResponse, InfraService.BadResponse>(request, urlService, int.Parse(timeoutService)).GetAwaiter().GetResult();

        return (_mapper.Map<ServiceProcessLoadResponse>(successResponse), _mapper.Map<BadResponse>(badResponse));
    }
}
