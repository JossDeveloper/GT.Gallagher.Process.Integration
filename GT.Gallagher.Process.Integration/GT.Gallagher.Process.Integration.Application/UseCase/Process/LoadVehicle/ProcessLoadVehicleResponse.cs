using GT.Gallagher.Process.Integration.Domain.Base;
using GT.Gallagher.Process.Integration.Domain.Process;

namespace GT.Gallagher.Process.Integration.Application.UseCase.Process.LoadVehicle;

public class ProcessLoadVehicleResponse
{
    public string CodResponse { get; private set; }
    public string TxtResponse { get; private set; }
    public List<ProblemDetail> Details { get; private set; }
    public ProcessLoadOutput? Output { get; private set; }

    public ProcessLoadVehicleResponse(string codResponse, string txtResponse, List<ProblemDetail> details, ProcessLoadOutput? output)
    {
        CodResponse = codResponse;
        TxtResponse = txtResponse;
        Details = details;
        Output = output;
    }
}
