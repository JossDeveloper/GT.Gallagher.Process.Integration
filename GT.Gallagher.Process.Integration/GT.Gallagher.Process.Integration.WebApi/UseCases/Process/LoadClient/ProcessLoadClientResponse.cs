using GT.Gallagher.Process.Integration.WebApi.Model.Process;

namespace GT.Gallagher.Process.Integration.WebApi.UseCases.Process.LoadClient;

public class ProcessLoadClientResponse : StandardResponse
{
    public ProcessLoadOutput? Output { get; set; }

    public ProcessLoadClientResponse(string codResponse, string txtResponse)
    {
        CodResponse = codResponse;
        TxtResponse = txtResponse;
    }
}
