namespace GT.Gallagher.Process.Integration.Domain.Process.LoadPolicy;

public class ProcessLoadPolicyContent
{
    public int RowNumber { get; private set; }
    public ProcessLoadPolicy ProcessLoadPolicy { get; private set; }

    public ProcessLoadPolicyContent(int rowNumber, ProcessLoadPolicy processLoadPolicy)
    {
        RowNumber = rowNumber;
        ProcessLoadPolicy = processLoadPolicy;
    }
}
