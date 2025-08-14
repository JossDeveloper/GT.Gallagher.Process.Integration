using GT.Gallagher.Process.Integration.Domain.Common;
using GT.Gallagher.Process.Integration.Domain.Process;
using GT.Gallagher.Process.Integration.Domain.Process.LoadVehicle;
using GT.Gallagher.Process.Integration.Domain.Records;

namespace GT.Gallagher.Process.Integration.Application.UseCase.Process.LoadVehicle;

public class ProcessLoadVehicleRequest : StandardRequest
{
    public ProcessLoadInput Input { get; private set; }
    public List<(int, string)> FileLines { get; set; }

    public List<ProcessLoadVehicleContent> ProcessLoadContents { get; set; }
    public List<ProcessLoadVehicleDetails> ProcessLoadDetails { get; set; }
    public List<ProcessLoadVehicle> VehiclesToProcess { get; set; }
    public List<ProcessLoadVehicleFeedBack> MasterDetailsFeedBack { get; set; }
    public string FeedBack { get; set; }
    public int? SuccessSaved { get; set; } = null;
    public Guid MasterCode { get; set; } = Guid.NewGuid();
    public ScheduledProcesses ScheduledProcesses { get; set; }
    public RepositoryServer RepositoryServer { get; set; }
    public ProcessLoadOutput Output { get; set; }

    public ProcessLoadVehicleRequest(Record record, ProcessLoadInput input)
    {
        Record = record;
        Input = input;
        FileLines = new List<(int, string)>();
        ProcessLoadContents = new List<ProcessLoadVehicleContent>();
        ProcessLoadDetails = new List<ProcessLoadVehicleDetails>();
        VehiclesToProcess = new List<ProcessLoadVehicle>();
    }
}
