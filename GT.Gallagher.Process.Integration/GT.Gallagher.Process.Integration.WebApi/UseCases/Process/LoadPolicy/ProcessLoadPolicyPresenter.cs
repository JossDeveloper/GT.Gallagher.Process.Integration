using GlobalTpa.Extension.Startup.WebApi.Model;
using GT.Gallagher.Process.Integration.Application.Boundaries;
using GT.Gallagher.Process.Integration.WebApi.Model;
using GT.Gallagher.Process.Integration.WebApi.Model.Process;
using Microsoft.AspNetCore.Mvc;

using App = GT.Gallagher.Process.Integration.Application.UseCase.Process.LoadPolicy;

namespace GT.Gallagher.Process.Integration.WebApi.UseCases.Process.LoadPolicy;

public class ProcessLoadPolicyPresenter : Presenter, IOutputPort<App.ProcessLoadPolicyResponse>
{
    public void Standard(App.ProcessLoadPolicyResponse output)
    {
        var response = new ProcessLoadPolicyResponse(output.CodResponse, output.TxtResponse);
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
