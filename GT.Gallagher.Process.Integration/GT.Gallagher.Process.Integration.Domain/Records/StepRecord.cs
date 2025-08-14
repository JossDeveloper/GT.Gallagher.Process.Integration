using GT.Gallagher.Process.Integration.Domain.Enum;
using GT.Gallagher.Process.Integration.Domain.Helper;
using System.ComponentModel.DataAnnotations.Schema;

namespace GT.Gallagher.Process.Integration.Domain.Records;

public class StepRecord
{
    public string? Description { get; private set; }
    public string? OutputJson { get; set; } = null;
    public string? Message { get; private set; }
    [NotMapped]
    public RecordType RecordType { get; private set; }
    public string? Type { get => Util.GetEnumMemberValue(RecordType); }
    public DateTime? HistoryDate { get; private set; } = DateTime.Now;

    public StepRecord(string? description, string? message, RecordType recordType)
    {
        Description = description;
        Message = message;
        RecordType = recordType;
    }
}
