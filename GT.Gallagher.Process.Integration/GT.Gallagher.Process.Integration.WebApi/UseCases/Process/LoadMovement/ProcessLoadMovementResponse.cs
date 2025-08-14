using GT.Gallagher.Process.Integration.WebApi.Model.Process;

namespace GT.Gallagher.Process.Integration.WebApi.UseCases.Process.LoadMovement;

public class ProcessLoadMovementResponse : StandardResponse
{
    public ProcessLoadOutput? Output { get; set; }

    public ProcessLoadMovementResponse(string codResponse, string txtResponse)
    {
        CodResponse = codResponse;
        TxtResponse = txtResponse;
    }
}
