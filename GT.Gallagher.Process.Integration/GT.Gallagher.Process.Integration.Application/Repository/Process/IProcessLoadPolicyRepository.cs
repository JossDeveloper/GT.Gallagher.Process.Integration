using GT.Gallagher.Process.Integration.Domain.Common;
using GT.Gallagher.Process.Integration.Domain.Process.LoadPolicy;

namespace GT.Gallagher.Process.Integration.Application.Repository.Process;

public interface IProcessLoadPolicyRepository
{
    int GenerateProcess(Guid code, Guid scheduledProcess, int userId);
    int SaveProcessMaster(Guid masterCode, int userId, Guid processCode, Guid uniqueName, string fileName, string ext, List<ProcessLoadPolicyDetails> processLoadDetails, int quantityRows);
    List<(int, string)> ReadContentFile(byte[] bytes);
    List<ProcessLoadPolicyContent> BuildContentFile(List<(int, string)> lines);
    List<ProcessLoadPolicyFeedBack> GetMasterDetailsFeedBack(Guid masterCode);
    byte[] GenerateExcelToAttach(List<ProcessLoadPolicyFeedBack> masterDetailsFeedBack);
    void PutSftpFilesHistory(RepositoryServer repository, string fileName, byte[] filebytes);
    int LoadDataToProcess(Guid masterCode);
    int ProcessPolicyPlotData(Guid masterCode);
    int EndProcessMaster(Guid masterCode, string feedback);
}
