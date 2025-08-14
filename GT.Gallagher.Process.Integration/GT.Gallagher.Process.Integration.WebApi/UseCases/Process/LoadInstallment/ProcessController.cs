using GlobalTpa.Extension.Startup.WebApi.Model;
using GT.Gallagher.Process.Integration.Application.UseCase.Process.LoadInstallment;
using GT.Gallagher.Process.Integration.Domain.Common;
using GT.Gallagher.Process.Integration.Domain.Process;
using GT.Gallagher.Process.Integration.Domain.Records;
using Microsoft.AspNetCore.Mvc;

using App = GT.Gallagher.Process.Integration.Application.UseCase.Process.LoadInstallment;

namespace GT.Gallagher.Process.Integration.WebApi.UseCases.Process.LoadInstallment;

[Route("api/[controller]")]
[ApiController]
public class ProcessController : ControllerBase
{
    private readonly IProcessLoadInstallmentUseCase processLoadInstallmentUseCase;
    private readonly ProcessLoadInstallmentPresenter processLoadInstallmentPresenter;

    public ProcessController(IProcessLoadInstallmentUseCase processLoadInstallmentUseCase, ProcessLoadInstallmentPresenter processLoadInstallmentPresenter)
    {
        this.processLoadInstallmentUseCase = processLoadInstallmentUseCase;
        this.processLoadInstallmentPresenter = processLoadInstallmentPresenter;
    }


    [HttpPost()]
    [ProducesResponseType(typeof(ProcessLoadInstallmentResponse), 200)]
    [ProducesResponseType(typeof(ProblemDetailsBadRequest), 400)]
    [ProducesResponseType(typeof(ProblemDetailsOtherRequest), 401)]
    [ProducesResponseType(typeof(ProblemDetailsOtherRequest), 500)]
    [Route("LoadInstallment")]
    public async Task<IActionResult> Installment([FromForm] ProcessLoadInstallmentRequest request)
    {
        byte[] fileBytes;

        using (var ms = new MemoryStream())
        {
            await request.File?.CopyToAsync(ms);
            fileBytes = ms.ToArray();
        }
        var record = new Record(
            nameof(ProcessController),
            nameof(Installment),
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
        var appRequest = new App.ProcessLoadInstallmentRequest(record, input);

        await processLoadInstallmentUseCase.Execute(appRequest);

        return processLoadInstallmentPresenter.ViewModel;
    }
}
