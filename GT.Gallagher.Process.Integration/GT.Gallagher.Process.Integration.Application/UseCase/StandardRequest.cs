using GT.Gallagher.Process.Integration.Domain.Base;
using GT.Gallagher.Process.Integration.Domain.Enum;
using GT.Gallagher.Process.Integration.Domain.Records;

namespace GT.Gallagher.Process.Integration.Application.UseCase;

public class StandardRequest
{
    public string CodResponse { get; set; }
    public string TxtResponse { get; set; }
    public List<ProblemDetail> Details { get; set; }
    public List<ValidationFailure> ValidationFailures { get; set; }
    public Record Record { get; set; }
    public List<StepRecord> StepRecords { get; set; } = new();


    public StandardRequest()
    {
        CodResponse = "00";
        TxtResponse = "Proceso satisfactorio.";
        Details = new List<ProblemDetail>();
        ValidationFailures = new List<ValidationFailure>();
        StepRecords = new List<StepRecord>();
    }

    public void AddRecord(string description, string message, RecordType recordType)
        => StepRecords.Add(new StepRecord(description, message, recordType));
    public void StartRecord(string description)
    => StepRecords.Add(new StepRecord(description, "Init process", RecordType.Start));
    public void EndRecord(string description)
        => StepRecords.Add(new StepRecord(description, "End process", RecordType.End));
    public void ErrorRecord(string description, Exception ex)
        => StepRecords.Add(new StepRecord(description, $"Error on process: {ex.InnerException?.Message ?? ex.Message}", RecordType.Error));
}

