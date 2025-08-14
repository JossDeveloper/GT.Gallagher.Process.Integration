using GT.Gallagher.Process.Integration.WebApi.Model.Process;

namespace GT.Gallagher.Process.Integration.WebApi.UseCases.Process.LoadInstallment;

public class ProcessLoadInstallmentResponse : StandardResponse
{
    public ProcessLoadOutput? Output { get; set; }

    public ProcessLoadInstallmentResponse(string codResponse, string txtResponse)
    {
        CodResponse = codResponse;
        TxtResponse = txtResponse;
    }
}
