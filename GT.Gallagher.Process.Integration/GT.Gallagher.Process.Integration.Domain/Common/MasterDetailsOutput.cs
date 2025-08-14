namespace GT.Gallagher.Process.Integration.Domain.Common;

public class MasterDetailsOutput
{
    public Guid MasterCode { get; private set; }
    public int RowNumber { get; private set; }
    public string TextString { get; private set; }
    public string Details { get; private set; }
    public bool State { get; private set; }

    public MasterDetailsOutput(Guid masterCode, int rowNumber, string textString, string details, bool state)
    {
        MasterCode = masterCode;
        RowNumber = rowNumber;
        TextString = textString;
        Details = details;
        State = state;
    }
}
