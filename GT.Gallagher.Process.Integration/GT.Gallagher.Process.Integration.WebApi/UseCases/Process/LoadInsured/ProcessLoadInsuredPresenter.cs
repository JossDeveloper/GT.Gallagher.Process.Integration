using GlobalTpa.Extension.Startup.WebApi.Model;
using GT.Gallagher.Process.Integration.Application.Boundaries;
using GT.Gallagher.Process.Integration.WebApi.Model;
using GT.Gallagher.Process.Integration.WebApi.Model.Process;
using Microsoft.AspNetCore.Mvc;

using App = GT.Gallagher.Process.Integration.Application.UseCase.Process.LoadInsured;

namespace GT.Gallagher.Process.Integration.WebApi.UseCases.Process.LoadInsured;

public class ProcessLoadInsuredPresenter : Presenter, IOutputPort<App.ProcessLoadInsuredResponse>
{
    public void Standard(App.ProcessLoadInsuredResponse output)
    {
        var response = new ProcessLoadInsuredResponse(output.CodResponse, output.TxtResponse);
            response.Details.AddRange(output.Details.Select(s => new ProblemDetail(s.Title, s.Message)));

        if (output.Output is not null)
        {
            response.Output = new ProcessLoadOutput(
                output.Output.MasterCode,
                output.Output.Name,
                output.Output.QuantityRows);
        }
        ViewModel = new OkObjectResult(response);
    }
}
