using GT.Gallagher.Process.Integration.Domain.Base;

namespace GT.Gallagher.Process.Integration.Domain.Process.LoadMovement;

public class ProcessLoadMovementDetails
{
    public int RowNumber { get; private set; }
    public ProcessLoadMovement ProcessLoadMovement { get; private set; }
    public List<ProblemDetail> Details { get; private set; } = new();

    public ProcessLoadMovementDetails(int rowNumber, ProcessLoadMovement processLoadMovement, List<ProblemDetail> details)
    {
        RowNumber = rowNumber;
        ProcessLoadMovement = processLoadMovement;
        Details = details;
    }

    public ProcessLoadMovementDetails(int rowNumber, ProcessLoadMovement processLoadMovement, ProblemDetail detail)
    {
        RowNumber = rowNumber;
        ProcessLoadMovement = processLoadMovement;
        Details.Add(detail);
    }
}
