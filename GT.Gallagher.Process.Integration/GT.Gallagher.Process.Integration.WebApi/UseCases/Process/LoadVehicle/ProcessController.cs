using GlobalTpa.Extension.Startup.WebApi.Model;
using GT.Gallagher.Process.Integration.Application.UseCase.Process.LoadVehicle;
using GT.Gallagher.Process.Integration.Domain.Common;
using GT.Gallagher.Process.Integration.Domain.Process;
using GT.Gallagher.Process.Integration.Domain.Records;
using Microsoft.AspNetCore.Mvc;

using App = GT.Gallagher.Process.Integration.Application.UseCase.Process.LoadVehicle;

namespace GT.Gallagher.Process.Integration.WebApi.UseCases.Process.LoadVehicle;

[Route("api/[controller]")]
[ApiController]
public class ProcessController : ControllerBase
{
    private readonly IProcessLoadVehicleUseCase processLoadVehicleUseCase;
    private readonly ProcessLoadVehiclePresenter processLoadVehiclePresenter;

    public ProcessController(IProcessLoadVehicleUseCase processLoadVehicleUseCase, ProcessLoadVehiclePresenter processLoadVehiclePresenter)
    {
        this.processLoadVehicleUseCase = processLoadVehicleUseCase;
        this.processLoadVehiclePresenter = processLoadVehiclePresenter;
    }


    [HttpPost()]
    [ProducesResponseType(typeof(ProcessLoadVehicleResponse), 200)]
    [ProducesResponseType(typeof(ProblemDetailsBadRequest), 400)]
    [ProducesResponseType(typeof(ProblemDetailsOtherRequest), 401)]
    [ProducesResponseType(typeof(ProblemDetailsOtherRequest), 500)]
    [Route("LoadVehicle")]
    public async Task<IActionResult> Vehicle([FromForm] ProcessLoadVehicleRequest request)
    {
        byte[] fileBytes;

        using (var ms = new MemoryStream())
        {
            await request.File?.CopyToAsync(ms);
            fileBytes = ms.ToArray();
        }
        var record = new Record(
            nameof(ProcessController),
            nameof(Vehicle),
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
        var appRequest = new App.ProcessLoadVehicleRequest(record, input);

        await processLoadVehicleUseCase.Execute(appRequest);

        return processLoadVehiclePresenter.ViewModel;
    }
}
