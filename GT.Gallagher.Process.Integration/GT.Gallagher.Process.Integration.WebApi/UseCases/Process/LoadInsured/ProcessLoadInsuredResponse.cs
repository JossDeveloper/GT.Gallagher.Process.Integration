using GT.Gallagher.Process.Integration.WebApi.Model.Process;

namespace GT.Gallagher.Process.Integration.WebApi.UseCases.Process.LoadInsured;

public class ProcessLoadInsuredResponse : StandardResponse
{
    public ProcessLoadOutput? Output { get; set; }

    public ProcessLoadInsuredResponse(string codResponse, string txtResponse)
    {
        CodResponse = codResponse;
        TxtResponse = txtResponse;
    }
}
