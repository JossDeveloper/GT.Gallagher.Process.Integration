using GT.Gallagher.Process.Integration.WebApi.Model.Process;

namespace GT.Gallagher.Process.Integration.WebApi.UseCases.Process.LoadVehicle;

public class ProcessLoadVehicleResponse : StandardResponse
{
    public ProcessLoadOutput? Output { get; set; }

    public ProcessLoadVehicleResponse(string codResponse, string txtResponse)
    {
        CodResponse = codResponse;
        TxtResponse = txtResponse;
    }
}
