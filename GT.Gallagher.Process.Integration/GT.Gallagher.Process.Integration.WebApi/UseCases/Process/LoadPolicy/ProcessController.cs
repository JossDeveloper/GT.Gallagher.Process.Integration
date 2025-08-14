using GlobalTpa.Extension.Startup.WebApi.Model;
using GT.Gallagher.Process.Integration.Application.UseCase.Process.LoadPolicy;
using GT.Gallagher.Process.Integration.Domain.Common;
using GT.Gallagher.Process.Integration.Domain.Process;
using GT.Gallagher.Process.Integration.Domain.Records;
using Microsoft.AspNetCore.Mvc;

using App = GT.Gallagher.Process.Integration.Application.UseCase.Process.LoadPolicy;

namespace GT.Gallagher.Process.Integration.WebApi.UseCases.Process.LoadPolicy;

[Route("api/[controller]")]
[ApiController]
public class ProcessController : ControllerBase
{
    private readonly IProcessLoadPolicyUseCase processLoadPolicyUseCase;
    private readonly ProcessLoadPolicyPresenter processLoadPolicyPresenter;

    public ProcessController(IProcessLoadPolicyUseCase processLoadPolicyUseCase, ProcessLoadPolicyPresenter processLoadPolicyPresenter)
    {
        this.processLoadPolicyUseCase = processLoadPolicyUseCase;
        this.processLoadPolicyPresenter = processLoadPolicyPresenter;
    }


    [HttpPost()]
    [ProducesResponseType(typeof(ProcessLoadPolicyResponse), 200)]
    [ProducesResponseType(typeof(ProblemDetailsBadRequest), 400)]
    [ProducesResponseType(typeof(ProblemDetailsOtherRequest), 401)]
    [ProducesResponseType(typeof(ProblemDetailsOtherRequest), 500)]
    [Route("LoadPolicy")]
    public async Task<IActionResult> Policy([FromForm] ProcessLoadPolicyRequest request)
    {
        byte[] fileBytes;

        using (var ms = new MemoryStream())
        {
            await request.File?.CopyToAsync(ms);
            fileBytes = ms.ToArray();
        }
        var record = new Record(
            nameof(ProcessController),
            nameof(Policy),
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
        var appRequest = new App.ProcessLoadPolicyRequest(record, input);

        await processLoadPolicyUseCase.Execute(appRequest);

        return processLoadPolicyPresenter.ViewModel;
    }
}
