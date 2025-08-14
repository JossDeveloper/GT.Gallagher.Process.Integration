using GT.Gallagher.Process.Integration.Domain.Common;
using GT.Gallagher.Process.Integration.Domain.Process;
using GT.Gallagher.Process.Integration.Domain.Process.LoadMovement;
using GT.Gallagher.Process.Integration.Domain.Records;

namespace GT.Gallagher.Process.Integration.Application.UseCase.Process.LoadMovement;

public class ProcessLoadMovementRequest : StandardRequest
{
    public ProcessLoadInput Input { get; private set; }
    public List<(int, string)> FileLines { get; set; }

    public List<ProcessLoadMovementContent> ProcessLoadContents { get; set; }
    public List<ProcessLoadMovementDetails> ProcessLoadDetails { get; set; }
    public List<ProcessLoadMovement> MovementsToProcess { get; set; }
    public List<ProcessLoadMovementFeedBack> MasterDetailsFeedBack { get; set; }
    public string FeedBack { get; set; }
    public int? SuccessSaved { get; set; } = null;
    public Guid MasterCode { get; set; } = Guid.NewGuid();
    public ScheduledProcesses ScheduledProcesses { get; set; }
    public RepositoryServer RepositoryServer { get; set; }
    public ProcessLoadOutput Output { get; set; }

    public ProcessLoadMovementRequest(Record record, ProcessLoadInput input)
    {
        Record = record;
        Input = input;
        FileLines = new List<(int, string)>();
        ProcessLoadContents = new List<ProcessLoadMovementContent>();
        ProcessLoadDetails = new List<ProcessLoadMovementDetails>();
        MovementsToProcess = new List<ProcessLoadMovement>();
    }
}
