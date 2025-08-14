using GT.Gallagher.Process.Integration.Domain.Common;
using GT.Gallagher.Process.Integration.Domain.Gallagher.Process;
using GT.Gallagher.Process.Integration.Domain.TPAService.Base;

namespace GT.Gallagher.Process.Integration.Application.Repository.Recurrent;

public interface IRecurrentPlotRepository
{
    int CreateDirectoryToSaveFiles();
    List<SftpFile> GetSftpFiles(RepositoryServer repository, string plotName);
    void PutSftpFilesHistory(RepositoryServer repository, string customRoot, List<SftpFile> sftpFiles);
    (ServiceProcessLoadResponse?, BadResponse) SendToProcess(int userId, SftpFile sftpFile, string endpoint, string token);
}
