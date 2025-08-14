namespace GT.Gallagher.Process.Integration.Domain.Process.LoadClient;

public class ProcessLoadClientContent
{
    public int RowNumber { get; private set; }
    public ProcessLoadClient ProcessLoadClient { get; private set; }

    public ProcessLoadClientContent(int rowNumber, ProcessLoadClient processLoadClient)
    {
        RowNumber = rowNumber;
        ProcessLoadClient = processLoadClient;
    }
}
