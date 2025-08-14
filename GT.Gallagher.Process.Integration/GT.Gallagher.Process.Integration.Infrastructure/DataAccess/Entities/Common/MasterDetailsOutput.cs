namespace GT.Gallagher.Process.Integration.Infrastructure.DataAccess.Entities.Common;

public class MasterDetailsOutput
{
    public Guid MasterCode { get; private set; }
    public int RowNumber { get; private set; }
    public string TextString { get; private set; }
    public string Details { get; private set; }
    public bool State { get; private set; }
}
