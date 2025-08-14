using GT.Gallagher.Process.Integration.Application.Repository.Process;
using GT.Gallagher.Process.Integration.Application.UseCase.Handler;
using GT.Gallagher.Process.Integration.Domain.Enum;

namespace GT.Gallagher.Process.Integration.Application.UseCase.Process.LoadMovement.Handlers;

public class GenerateMainProcessHandler : Handler<ProcessLoadMovementRequest>
{
    private readonly IProcessLoadMovementRepository repository;

    public GenerateMainProcessHandler(IProcessLoadMovementRepository repository)
    {
        this.repository = repository;
    }

    public override async Task ProcessRequest(ProcessLoadMovementRequest request)
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
