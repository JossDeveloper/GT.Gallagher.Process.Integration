using GT.Gallagher.Process.Integration.Domain.Common;
using GT.Gallagher.Process.Integration.Domain.Process.LoadClient;

namespace GT.Gallagher.Process.Integration.Application.Repository.Process;

public interface IProcessLoadClientRepository
{
    int GenerateProcess(Guid code, Guid scheduledProcess, int userId);
    int SaveProcessMaster(Guid masterCode, int userId, Guid processCode, Guid uniqueName, string fileName, string ext, List<ProcessLoadClientDetails> feedbackdetails, int quantityRows);
    List<(int, string)> ReadContentFile(byte[] bytes);
    List<ProcessLoadClientContent> BuildContentFile(List<(int, string)> lines);
    List<ProcessLoadClientFeedBack> GetMasterDetailsFeedBack(Guid masterCode);
    byte[] GenerateExcelToAttach(List<ProcessLoadClientFeedBack> masterDetailsFeedBack);
    void PutSftpFilesHistory(RepositoryServer repository, string fileName, byte[] filebytes);
    int LoadDataToProcess(Guid masterCode);
    int ProcessClientPlotData(Guid masterCode);
    int EndProcessMaster(Guid masterCode, string feedback);
}
