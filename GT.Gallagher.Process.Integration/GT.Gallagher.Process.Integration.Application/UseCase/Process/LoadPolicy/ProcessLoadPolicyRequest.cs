using GT.Gallagher.Process.Integration.Domain.Common;
using GT.Gallagher.Process.Integration.Domain.Process;
using GT.Gallagher.Process.Integration.Domain.Process.LoadPolicy;
using GT.Gallagher.Process.Integration.Domain.Records;

namespace GT.Gallagher.Process.Integration.Application.UseCase.Process.LoadPolicy;

public class ProcessLoadPolicyRequest : StandardRequest
{
    public ProcessLoadInput Input { get; private set; }
    public List<(int, string)> FileLines { get; set; }

    public List<ProcessLoadPolicyContent> ProcessLoadContents { get; set; }
    public List<ProcessLoadPolicyDetails> ProcessLoadDetails { get; set; }
    public List<ProcessLoadPolicy> PoliciesToProcess { get; set; }
    public List<ProcessLoadPolicyFeedBack> MasterDetailsFeedBack { get; set; }
    public string FeedBack { get; set; }
    public int? SuccessSaved { get; set; } = null;
    public Guid MasterCode { get; set; } = Guid.NewGuid();
    public ScheduledProcesses ScheduledProcesses { get; set; }
    public RepositoryServer RepositoryServer { get; set; }
    public ProcessLoadOutput Output { get; set; }

    public ProcessLoadPolicyRequest(Record record, ProcessLoadInput input)
    {
        Record = record;
        Input = input;
        FileLines = new List<(int, string)>();
        ProcessLoadContents = new List<ProcessLoadPolicyContent>();
        ProcessLoadDetails = new List<ProcessLoadPolicyDetails>();
        PoliciesToProcess = new List<ProcessLoadPolicy>();
    }
}
