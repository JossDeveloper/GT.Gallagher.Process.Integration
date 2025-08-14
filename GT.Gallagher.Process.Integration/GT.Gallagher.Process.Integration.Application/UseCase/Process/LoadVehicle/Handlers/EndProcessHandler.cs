using GT.Gallagher.Process.Integration.Application.Repository.Process;
using GT.Gallagher.Process.Integration.Application.UseCase.Handler;
using GT.Gallagher.Process.Integration.Domain.Enum;

namespace GT.Gallagher.Process.Integration.Application.UseCase.Process.LoadVehicle.Handlers;

public class EndProcessHandler : Handler<ProcessLoadVehicleRequest>
{
    private readonly IProcessLoadVehicleRepository repository;

    public EndProcessHandler(IProcessLoadVehicleRepository repository)
    {
        this.repository = repository;
    }

    public override async Task ProcessRequest(ProcessLoadVehicleRequest request)
    {
        request.AddRecord(GetType().Name, "End process", RecordType.SetInformation);
        var result = repository.EndProcessMaster(request.MasterCode, request.FeedBack);
        request.StepRecords.LastOrDefault().OutputJson = $"{result}";

        if (result != 1)
        {
            request.CodResponse = "04";
            request.TxtResponse = "Proceso finalizó correctamente, pero no se pudo actualizar su estado en tabla procesos.";
            return;
        }
    }
}
