namespace GT.Gallagher.Process.Integration.Domain.Process.LoadInsured;

public class ProcessLoadInsuredContent
{
    public int RowNumber { get; private set; }
    public ProcessLoadInsured ProcessLoadInsured { get; private set; }

    public ProcessLoadInsuredContent(int rowNumber, ProcessLoadInsured processLoadInsured)
    {
        RowNumber = rowNumber;
        ProcessLoadInsured = processLoadInsured;
    }
}
