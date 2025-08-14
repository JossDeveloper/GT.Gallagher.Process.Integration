using GT.Gallagher.Process.Integration.Domain.Base;

namespace GT.Gallagher.Process.Integration.Domain.Process.LoadClient;

public class ProcessLoadClientDetails
{
    public int RowNumber { get; private set; }
    public ProcessLoadClient ProcessLoadClient { get; private set; }
    public List<ProblemDetail> Details { get; private set; } = new();

    public ProcessLoadClientDetails(int rowNumber, ProcessLoadClient processLoadClient, List<ProblemDetail> details)
    {
        RowNumber = rowNumber;
        ProcessLoadClient = processLoadClient;
        Details = details;
    }

    public ProcessLoadClientDetails(int rowNumber, ProcessLoadClient processLoadClient, ProblemDetail detail)
    {
        RowNumber = rowNumber;
        ProcessLoadClient = processLoadClient;
        Details.Add(detail);
    }
}
