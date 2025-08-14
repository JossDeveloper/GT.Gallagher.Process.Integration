using GT.Gallagher.Process.Integration.Domain.Common;
using GT.Gallagher.Process.Integration.Domain.Process.LoadInsured;

namespace GT.Gallagher.Process.Integration.Application.Repository.Process;

public interface IProcessLoadInsuredRepository
{
    int GenerateProcess(Guid code, Guid scheduledProcess, int userId);
    int SaveProcessMaster(Guid masterCode, int userId, Guid processCode, Guid uniqueName, string fileName, string ext, List<ProcessLoadInsuredDetails> processLoadDetails, int quantityRows);
    List<(int, string)> ReadContentFile(byte[] bytes);
    List<ProcessLoadInsuredContent> BuildContentFile(List<(int, string)> lines);
    List<ProcessLoadInsuredFeedBack> GetMasterDetailsFeedBack(Guid masterCode);
    byte[] GenerateExcelToAttach(List<ProcessLoadInsuredFeedBack> masterDetailsFeedBack);
    void PutSftpFilesHistory(RepositoryServer repository, string fileName, byte[] filebytes);
    int LoadDataToProcess(Guid masterCode);
    int ProcessInsuredPlotData(Guid masterCode);
    int EndProcessMaster(Guid masterCode, string feedback);
}
