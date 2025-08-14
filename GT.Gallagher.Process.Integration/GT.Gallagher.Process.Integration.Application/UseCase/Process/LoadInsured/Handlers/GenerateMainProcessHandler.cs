using GT.Gallagher.Process.Integration.Application.Repository.Process;
using GT.Gallagher.Process.Integration.Application.UseCase.Handler;
using GT.Gallagher.Process.Integration.Domain.Enum;

namespace GT.Gallagher.Process.Integration.Application.UseCase.Process.LoadInsured.Handlers;

public class GenerateMainProcessHandler : Handler<ProcessLoadInsuredRequest>
{
    private readonly IProcessLoadInsuredRepository repository;

    public GenerateMainProcessHandler(IProcessLoadInsuredRepository repository)
    {
        this.repository = repository;
    }

    public override async Task ProcessRequest(ProcessLoadInsuredRequest request)
    {
        request.AddRecord(GetType().Name, "Main Process - Generate", RecordType.SetInformation);

        var result = repository.GenerateProcess(
            request.Input.ProcessCode,
            request.ScheduledProcesses.Code,
            request.Input.UserId);

        request.StepRecords.LastOrDefault().OutputJson = $"{result}";

        if (result != 1)
        {
            request.CodResponse = "04";
            request.TxtResponse = "No se pudo generar el registro del proceso.";
            return;
        }
        await sucessor?.ProcessRequest(request);
    }
}
