namespace GT.Gallagher.Process.Integration.Infrastructure.DataAccess.Entities.Records;

public class StepRecord
{
    public string? Description { get; private set; }
    public string? OutputJson { get; private set; }
    public string? Message { get; private set; }
    public string? Type { get; private set; }
    public DateTime? HistoryDate { get; private set; }

    public StepRecord(string? description, string? outputJson, string? message, string? type, DateTime? historyDate)
    {
        Description = description;
        OutputJson = outputJson;
        Message = message;
        Type = type;
        HistoryDate = historyDate;
    }
}
