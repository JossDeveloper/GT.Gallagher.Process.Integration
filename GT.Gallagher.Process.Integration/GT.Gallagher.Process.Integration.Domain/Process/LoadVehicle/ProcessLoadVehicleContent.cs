namespace GT.Gallagher.Process.Integration.Domain.Process.LoadVehicle;

public class ProcessLoadVehicleContent
{
    public int RowNumber { get; private set; }
    public ProcessLoadVehicle ProcessLoadVehicle { get; private set; }

    public ProcessLoadVehicleContent(int rowNumber, ProcessLoadVehicle processLoadVehicle)
    {
        RowNumber = rowNumber;
        ProcessLoadVehicle = processLoadVehicle;
    }
}
