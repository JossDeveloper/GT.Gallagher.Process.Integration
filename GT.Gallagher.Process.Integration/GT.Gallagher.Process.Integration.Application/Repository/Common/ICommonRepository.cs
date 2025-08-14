using GT.Gallagher.Process.Integration.Domain.Common;

namespace GT.Gallagher.Process.Integration.Application.Repository.Common;

public interface ICommonRepository
{
    ScheduledProcesses GetScheduledProcesses(Guid code, Int16 process);
    RepositoryServer GetRepositorySftp(Guid? code);
    List<MasterDetailsOutput> GetMasterDetails(Guid masterCodes);
}
