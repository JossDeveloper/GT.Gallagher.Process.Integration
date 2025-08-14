using GT.Gallagher.Process.Integration.Domain.Base;

namespace GT.Gallagher.Process.Integration.Domain.Process.LoadVehicle;

public class ProcessLoadVehicleDetails
{
    public int RowNumber { get; private set; }
    public ProcessLoadVehicle ProcessLoadVehicle { get; private set; }
    public List<ProblemDetail> Details { get; private set; } = new();

    public ProcessLoadVehicleDetails(int rowNumber, ProcessLoadVehicle processLoadVehicle, List<ProblemDetail> details)
    {
        RowNumber = rowNumber;
        ProcessLoadVehicle = processLoadVehicle;
        Details = details;
    }

    public ProcessLoadVehicleDetails(int rowNumber, ProcessLoadVehicle processLoadVehicle, ProblemDetail detail)
    {
        RowNumber = rowNumber;
        ProcessLoadVehicle = processLoadVehicle;
        Details.Add(detail);
    }
}
