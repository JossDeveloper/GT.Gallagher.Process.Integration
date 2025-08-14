using GlobalTpa.Extension.Startup.WebApi.Model;
using GT.Gallagher.Process.Integration.Application.UseCase.Process.LoadClient;
using GT.Gallagher.Process.Integration.Domain.Common;
using GT.Gallagher.Process.Integration.Domain.Process;
using GT.Gallagher.Process.Integration.Domain.Records;
using Microsoft.AspNetCore.Mvc;

using App = GT.Gallagher.Process.Integration.Application.UseCase.Process.LoadClient;

namespace GT.Gallagher.Process.Integration.WebApi.UseCases.Process.LoadClient;

[Route("api/[controller]")]
[ApiController]
public class ProcessController : ControllerBase
{
    private readonly IProcessLoadClientUseCase processLoadClientUseCase;
    private readonly ProcessLoadClientPresenter processLoadClientPresenter;

    public ProcessController(IProcessLoadClientUseCase processLoadClientUseCase, ProcessLoadClientPresenter processLoadClientPresenter)
    {
        this.processLoadClientUseCase = processLoadClientUseCase;
        this.processLoadClientPresenter = processLoadClientPresenter;
    }


    [HttpPost()]
    [ProducesResponseType(typeof(ProcessLoadClientResponse), 200)]
    [ProducesResponseType(typeof(ProblemDetailsBadRequest), 400)]
    [ProducesResponseType(typeof(ProblemDetailsOtherRequest), 401)]
    [ProducesResponseType(typeof(ProblemDetailsOtherRequest), 500)]
    [Route("LoadClient")]
    public async Task<IActionResult> Client([FromForm] ProcessLoadClientRequest request)
    {
        byte[] fileBytes;

        using (var ms = new MemoryStream())
        {
            await request.File?.CopyToAsync(ms);
            fileBytes = ms.ToArray();
        }
        var record = new Record(
            nameof(ProcessController),
            nameof(Client),
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
        var appRequest = new App.ProcessLoadClientRequest(record, input);

        await processLoadClientUseCase.Execute(appRequest);

        return processLoadClientPresenter.ViewModel;
    }
}
