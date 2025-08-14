using GT.Gallagher.Process.Integration.Domain.Base;

namespace GT.Gallagher.Process.Integration.Domain.Process.LoadPolicy;

public class ProcessLoadPolicyDetails
{
    public int RowNumber { get; private set; }
    public ProcessLoadPolicy ProcessLoadPolicy { get; private set; }
    public List<ProblemDetail> Details { get; private set; } = new();

    public ProcessLoadPolicyDetails(int rowNumber, ProcessLoadPolicy processLoadPolicy, List<ProblemDetail> details)
    {
        RowNumber = rowNumber;
        ProcessLoadPolicy = processLoadPolicy;
        Details = details;
    }

    public ProcessLoadPolicyDetails(int rowNumber, ProcessLoadPolicy processLoadPolicy, ProblemDetail detail)
    {
        RowNumber = rowNumber;
        ProcessLoadPolicy = processLoadPolicy;
        Details.Add(detail);
    }
}
