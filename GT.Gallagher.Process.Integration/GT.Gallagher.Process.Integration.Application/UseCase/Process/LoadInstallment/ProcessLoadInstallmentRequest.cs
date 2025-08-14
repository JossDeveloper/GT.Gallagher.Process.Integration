using GT.Gallagher.Process.Integration.Domain.Common;
using GT.Gallagher.Process.Integration.Domain.Process;
using GT.Gallagher.Process.Integration.Domain.Process.LoadInstallment;
using GT.Gallagher.Process.Integration.Domain.Records;

namespace GT.Gallagher.Process.Integration.Application.UseCase.Process.LoadInstallment;

public class ProcessLoadInstallmentRequest : StandardRequest
{
    public ProcessLoadInput Input { get; private set; }
    public List<(int, string)> FileLines { get; set; }

    public List<ProcessLoadInstallmentContent> ProcessLoadContents { get; set; }
    public List<ProcessLoadInstallmentDetails> ProcessLoadDetails { get; set; }
    public List<ProcessLoadInstallment> InstallmentsToProcess { get; set; }
    public List<ProcessLoadInstallmentFeedBack> MasterDetailsFeedBack { get; set; }
    public string FeedBack { get; set; }
    public int? SuccessSaved { get; set; } = null;
    public Guid MasterCode { get; set; } = Guid.NewGuid();
    public ScheduledProcesses ScheduledProcesses { get; set; }
    public RepositoryServer RepositoryServer { get; set; }
    public ProcessLoadOutput Output { get; set; }

    public ProcessLoadInstallmentRequest(Record record, ProcessLoadInput input)
    {
        Record = record;
        Input = input;
        FileLines = new List<(int, string)>();
        ProcessLoadContents = new List<ProcessLoadInstallmentContent>();
        ProcessLoadDetails = new List<ProcessLoadInstallmentDetails>();
        InstallmentsToProcess = new List<ProcessLoadInstallment>();
    }
}
