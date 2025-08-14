using GT.Gallagher.Process.Integration.Domain.Common;
using GT.Gallagher.Process.Integration.Domain.Process.LoadVehicle;

namespace GT.Gallagher.Process.Integration.Application.Repository.Process;

public interface IProcessLoadVehicleRepository
{
    int GenerateProcess(Guid code, Guid scheduledProcess, int userId);
    int SaveProcessMaster(Guid masterCode, int userId, Guid processCode, Guid uniqueName, string fileName, string ext, List<ProcessLoadVehicleDetails> processLoadDetails, int quantityRows);
    List<(int, string)> ReadContentFile(byte[] bytes);
    List<ProcessLoadVehicleContent> BuildContentFile(List<(int, string)> lines);
    List<ProcessLoadVehicleFeedBack> GetMasterDetailsFeedBack(Guid masterCode);
    byte[] GenerateExcelToAttach(List<ProcessLoadVehicleFeedBack> masterDetailsFeedBack);
    void PutSftpFilesHistory(RepositoryServer repository, string fileName, byte[] filebytes);
    int LoadDataToProcess(Guid masterCode);
    int ProcessVehiclePlotData(Guid masterCode);
    int EndProcessMaster(Guid masterCode, string feedback);
}
