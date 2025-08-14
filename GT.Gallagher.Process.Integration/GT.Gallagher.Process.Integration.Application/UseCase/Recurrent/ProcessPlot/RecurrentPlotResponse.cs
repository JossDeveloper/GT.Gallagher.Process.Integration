using GT.Gallagher.Process.Integration.Domain.Base;
using GT.Gallagher.Process.Integration.Domain.Process;

namespace GT.Gallagher.Process.Integration.Application.UseCase.Recurrent.ProcessPlot;

public class RecurrentPlotResponse
{
    public string CodResponse { get; private set; }
    public string TxtResponse { get; private set; }
    public ProcessLoadOutput Output { get; private set; }
    public List<ProblemDetail> Details { get; private set; }

    public RecurrentPlotResponse(string codResponse, string txtResponse, ProcessLoadOutput output, List<ProblemDetail> details)
    {
        CodResponse = codResponse;
        TxtResponse = txtResponse;
        Output = output;
        Details = details;
    }
}
