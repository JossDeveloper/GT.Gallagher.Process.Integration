namespace GT.Gallagher.Process.Integration.Infrastructure.DataAccess.Entities.Records;

public class Record
{
    public Guid RecordCode { get; private set; }
    public string? Service { get; private set; }
    public string RequestJson { get; private set; }
    public string? CodResponse { get; private set; }
    public string? TxtResponse { get; private set; }
    public DateTime CreationDate { get; private set; }
}
