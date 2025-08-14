using GlobalTpa.Extension.Startup.WebApi.Model;
using GT.Gallagher.Process.Integration.Application.UseCase.Process.LoadInsured;
using GT.Gallagher.Process.Integration.Domain.Common;
using GT.Gallagher.Process.Integration.Domain.Process;
using GT.Gallagher.Process.Integration.Domain.Records;
using Microsoft.AspNetCore.Mvc;

using App = GT.Gallagher.Process.Integration.Application.UseCase.Process.LoadInsured;

namespace GT.Gallagher.Process.Integration.WebApi.UseCases.Process.LoadInsured;

[Route("api/[controller]")]
[ApiController]
public class ProcessController : ControllerBase
{
    private readonly IProcessLoadInsuredUseCase processLoadInsuredUseCase;
    private readonly ProcessLoadInsuredPresenter processLoadInsuredPresenter;

    public ProcessController(IProcessLoadInsuredUseCase processLoadInsuredUseCase, ProcessLoadInsuredPresenter processLoadInsuredPresenter)
    {
        this.processLoadInsuredUseCase = processLoadInsuredUseCase;
        this.processLoadInsuredPresenter = processLoadInsuredPresenter;
    }


    [HttpPost()]
    [ProducesResponseType(typeof(ProcessLoadInsuredResponse), 200)]
    [ProducesResponseType(typeof(ProblemDetailsBadRequest), 400)]
    [ProducesResponseType(typeof(ProblemDetailsOtherRequest), 401)]
    [ProducesResponseType(typeof(ProblemDetailsOtherRequest), 500)]
    [Route("LoadInsured")]
    public async Task<IActionResult> Insured([FromForm] ProcessLoadInsuredRequest request)
    {
        byte[] fileBytes;

        using (var ms = new MemoryStream())
        {
            await request.File?.CopyToAsync(ms);
            fileBytes = ms.ToArray();
        }
        var record = new Record(
            nameof(ProcessController),
            nameof(Insured),
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
        var appRequest = new App.ProcessLoadInsuredRequest(record, input);

        await processLoadInsuredUseCase.Execute(appRequest);

        return processLoadInsuredPresenter.ViewModel;
    }
}
