namespace GT.Gallagher.Process.Integration.Domain.Process.LoadMovement;

public class ProcessLoadMovementContent
{
    public int RowNumber { get; private set; }
    public ProcessLoadMovement ProcessLoadMovement { get; private set; }

    public ProcessLoadMovementContent(int rowNumber, ProcessLoadMovement processLoadMovement)
    {
        RowNumber = rowNumber;
        ProcessLoadMovement = processLoadMovement;
    }
}
