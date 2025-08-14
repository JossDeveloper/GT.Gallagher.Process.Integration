using GT.Gallagher.Process.Integration.Domain.Base;

namespace GT.Gallagher.Process.Integration.Domain.Process.LoadInsured;

public class ProcessLoadInsuredDetails
{
    public int RowNumber { get; private set; }
    public ProcessLoadInsured ProcessLoadInsured { get; private set; }
    public List<ProblemDetail> Details { get; private set; } = new();

    public ProcessLoadInsuredDetails(int rowNumber, ProcessLoadInsured processLoadInsured, List<ProblemDetail> details)
    {
        RowNumber = rowNumber;
        ProcessLoadInsured = processLoadInsured;
        Details = details;
    }

    public ProcessLoadInsuredDetails(int rowNumber, ProcessLoadInsured processLoadInsured, ProblemDetail detail)
    {
        RowNumber = rowNumber;
        ProcessLoadInsured = processLoadInsured;
        Details.Add(detail);
    }
}
