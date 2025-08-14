using GT.Gallagher.Process.Integration.Domain.Common;
using GT.Gallagher.Process.Integration.Domain.Process.LoadMovement;

namespace GT.Gallagher.Process.Integration.Application.Repository.Process;

public interface IProcessLoadMovementRepository
{
    int GenerateProcess(Guid code, Guid scheduledProcess, int userId);
    int SaveProcessMaster(Guid masterCode, int userId, Guid processCode, Guid uniqueName, string fileName, string ext, List<ProcessLoadMovementDetails> processLoadDetails, int quantityRows);
    List<(int, string)> ReadContentFile(byte[] bytes);
    List<ProcessLoadMovementContent> BuildContentFile(List<(int, string)> lines);
    List<ProcessLoadMovementFeedBack> GetMasterDetailsFeedBack(Guid masterCode);
    byte[] GenerateExcelToAttach(List<ProcessLoadMovementFeedBack> masterDetailsFeedBack);
    void PutSftpFilesHistory(RepositoryServer repository, string fileName, byte[] filebytes);
    int LoadDataToProcess(Guid masterCode);
    int ProcessMovementPlotData(Guid masterCode);
    int EndProcessMaster(Guid masterCode, string feedback);
}
