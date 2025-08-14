using GlobalTpa.Extension.Startup.WebApi.Model;
using GT.Gallagher.Process.Integration.Application.UseCase.Process.LoadMovement;
using GT.Gallagher.Process.Integration.Domain.Common;
using GT.Gallagher.Process.Integration.Domain.Process;
using GT.Gallagher.Process.Integration.Domain.Records;
using Microsoft.AspNetCore.Mvc;

using App = GT.Gallagher.Process.Integration.Application.UseCase.Process.LoadMovement;

namespace GT.Gallagher.Process.Integration.WebApi.UseCases.Process.LoadMovement;

[Route("api/[controller]")]
[ApiController]
public class ProcessController : ControllerBase
{
    private readonly IProcessLoadMovementUseCase processLoadMovementUseCase;
    private readonly ProcessLoadMovementPresenter processLoadMovementPresenter;

    public ProcessController(IProcessLoadMovementUseCase processLoadMovementUseCase, ProcessLoadMovementPresenter processLoadMovementPresenter)
    {
        this.processLoadMovementUseCase = processLoadMovementUseCase;
        this.processLoadMovementPresenter = processLoadMovementPresenter;
    }


    [HttpPost()]
    [ProducesResponseType(typeof(ProcessLoadMovementResponse), 200)]
    [ProducesResponseType(typeof(ProblemDetailsBadRequest), 400)]
    [ProducesResponseType(typeof(ProblemDetailsOtherRequest), 401)]
    [ProducesResponseType(typeof(ProblemDetailsOtherRequest), 500)]
    [Route("LoadMovement")]
    public async Task<IActionResult> Movement([FromForm] ProcessLoadMovementRequest request)
    {
        byte[] fileBytes;

        using (var ms = new MemoryStream())
        {
            await request.File?.CopyToAsync(ms);
            fileBytes = ms.ToArray();
        }
        var record = new Record(
            nameof(ProcessController),
            nameof(Movement),
            request,
            "00",
            "Start");
        var input = new ProcessLoadInput(
            request.UserId,
            request.ProcessCode,
            request.UniqueName,
            new FileInput(
                request.File?.FileName,
                fileBytes,
                request.File?.ContentType)
            );
        var appRequest = new App.ProcessLoadMovementRequest(record, input);

        await processLoadMovementUseCase.Execute(appRequest);

        return processLoadMovementPresenter.ViewModel;
    }
}
