using GlobalTpa.Extension.Startup.WebApi.Model;
using GT.Gallagher.Process.Integration.Application.UseCase.Recurrent.ProcessPlot;
using GT.Gallagher.Process.Integration.Domain.Records;
using GT.Gallagher.Process.Integration.Domain.Recurrent.ProcessPlot;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using App = GT.Gallagher.Process.Integration.Application.UseCase.Recurrent.ProcessPlot;

namespace GT.Gallagher.Process.Integration.WebApi.UseCases.Recurrent.ProcessPlot;

[Route("api/[controller]")]
[Authorize]
[ApiController]
public class RecurrentController : ControllerBase
{
    private readonly IRecurrentPlotUseCase recurrentPlotUseCase;
    private readonly RecurrentPlotPresenter presenter;

    public RecurrentController(IRecurrentPlotUseCase recurrentPlotUseCase, RecurrentPlotPresenter presenter)
    {
        this.recurrentPlotUseCase = recurrentPlotUseCase;
        this.presenter = presenter;
    }

    [HttpPost]
    [ProducesResponseType(typeof(RecurrentPlotResponse), 200)]
    [ProducesResponseType(typeof(ProblemDetailsBadRequest), 400)]
    [ProducesResponseType(typeof(ProblemDetailsOtherRequest), 401)]
    [ProducesResponseType(typeof(ProblemDetailsOtherRequest), 500)]
    [Route("[action]")]
    public IActionResult ProcessPlot([FromBody] RecurrentPlotRequest request)
    {
        var record = new Record(nameof(RecurrentController), nameof(ProcessPlot), request, "00", "Start");
        var input = new RecurrentPlotInput(request.UserId, request.ProcessId);
        var appRequest = new App.RecurrentPlotRequest(record, input);

        recurrentPlotUseCase.Execute(appRequest);

        return presenter.ViewModel;
    }
}
