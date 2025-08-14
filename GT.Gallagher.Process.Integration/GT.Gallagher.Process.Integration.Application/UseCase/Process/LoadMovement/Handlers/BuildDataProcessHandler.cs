using GT.Gallagher.Process.Integration.Application.Repository.Process;
using GT.Gallagher.Process.Integration.Application.UseCase.Handler;
using GT.Gallagher.Process.Integration.Domain.Enum;

namespace GT.Gallagher.Process.Integration.Application.UseCase.Process.LoadMovement.Handlers;

public class BuildDataProcessHandler : Handler<ProcessLoadMovementRequest>
{
    private readonly IProcessLoadMovementRepository repository;

    public BuildDataProcessHandler(IProcessLoadMovementRepository repository)
    {
        this.repository = repository;
    }

    public override async Task ProcessRequest(ProcessLoadMovementRequest request)
    {
        request.AddRecord(GetType().Name, "Build Data to process in Database", RecordType.SetInformation);
        var result = repository.LoadDataToProcess(request.MasterCode);
        request.StepRecords.LastOrDefault().OutputJson = $"{result}";

        if (result != 1)
        {
            request.CodResponse = "04";
            request.TxtResponse = "No se pudo cargar la información en base de datos.";
            return;
        }
        await sucessor?.ProcessRequest(request);
    }
}
