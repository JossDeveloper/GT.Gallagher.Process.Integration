using GT.Gallagher.Process.Integration.Domain.Common;
using GT.Gallagher.Process.Integration.Domain.Process;
using GT.Gallagher.Process.Integration.Domain.Process.LoadInsured;
using GT.Gallagher.Process.Integration.Domain.Records;

namespace GT.Gallagher.Process.Integration.Application.UseCase.Process.LoadInsured;

public class ProcessLoadInsuredRequest : StandardRequest
{
    public ProcessLoadInput Input { get; private set; }
    public List<(int, string)> FileLines { get; set; }

    public List<ProcessLoadInsuredContent> ProcessLoadContents { get; set; }
    public List<ProcessLoadInsuredDetails> ProcessLoadDetails { get; set; }
    public List<ProcessLoadInsured> InsuredsToProcess { get; set; }
    public List<ProcessLoadInsuredFeedBack> MasterDetailsFeedBack { get; set; }
    public string FeedBack { get; set; }
    public int? SuccessSaved { get; set; } = null;
    public Guid MasterCode { get; set; } = Guid.NewGuid();
    public ScheduledProcesses ScheduledProcesses { get; set; }
    public RepositoryServer RepositoryServer { get; set; }
    public ProcessLoadOutput Output { get; set; }

    public ProcessLoadInsuredRequest(Record record, ProcessLoadInput input)
    {
        Record = record;
        Input = input;
        FileLines = new List<(int, string)>();
        ProcessLoadContents = new List<ProcessLoadInsuredContent>();
        ProcessLoadDetails = new List<ProcessLoadInsuredDetails>();
        InsuredsToProcess = new List<ProcessLoadInsured>();
    }
}
