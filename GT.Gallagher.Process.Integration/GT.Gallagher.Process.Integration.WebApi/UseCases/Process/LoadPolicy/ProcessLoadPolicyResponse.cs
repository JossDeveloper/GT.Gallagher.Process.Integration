using GT.Gallagher.Process.Integration.WebApi.Model.Process;

namespace GT.Gallagher.Process.Integration.WebApi.UseCases.Process.LoadPolicy;

public class ProcessLoadPolicyResponse : StandardResponse
{
    public ProcessLoadOutput? Output { get; set; }

    public ProcessLoadPolicyResponse(string codResponse, string txtResponse)
    {
        CodResponse = codResponse;
        TxtResponse = txtResponse;
    }
}
