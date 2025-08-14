using GT.Gallagher.Process.Integration.Domain.Common;
using GT.Gallagher.Process.Integration.Domain.Process.LoadInstallment;

namespace GT.Gallagher.Process.Integration.Application.Repository.Process;

public interface IProcessLoadInstallmentRepository
{
    int GenerateProcess(Guid code, Guid scheduledProcess, int userId);
    int SaveProcessMaster(Guid masterCode, int userId, Guid processCode, Guid uniqueName, string fileName, string ext, List<ProcessLoadInstallmentDetails> processLoadDetails, int quantityRows);
    List<(int, string)> ReadContentFile(byte[] bytes);
    List<ProcessLoadInstallmentContent> BuildContentFile(List<(int, string)> lines);
    List<ProcessLoadInstallmentFeedBack> GetMasterDetailsFeedBack(Guid masterCode);
    byte[] GenerateExcelToAttach(List<ProcessLoadInstallmentFeedBack> masterDetailsFeedBack);
    void PutSftpFilesHistory(RepositoryServer repository, string fileName, byte[] filebytes);
    int LoadDataToProcess(Guid masterCode);
    int ProcessInstallmentPlotData(Guid masterCode);
    int EndProcessMaster(Guid masterCode, string feedback);
}
