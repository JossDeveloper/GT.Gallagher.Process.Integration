using GT.Gallagher.Process.Integration.WebApi.Model.Process;

namespace GT.Gallagher.Process.Integration.WebApi.UseCases.Recurrent.ProcessPlot;

public class RecurrentPlotResponse : StandardResponse
{
    public ProcessLoadOutput? Output { get; set; }

    public RecurrentPlotResponse(string codResponse, string txtResponse)
    {
        CodResponse = codResponse;
        TxtResponse = txtResponse;
    }
}