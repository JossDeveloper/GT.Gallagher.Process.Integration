using GT.Gallagher.Process.Integration.Application.Repository.Process;
using GT.Gallagher.Process.Integration.Application.UseCase.Handler;
using GT.Gallagher.Process.Integration.Domain.Enum;

namespace GT.Gallagher.Process.Integration.Application.UseCase.Process.LoadVehicle.Handlers;

public class SendToProcessHandler : Handler<ProcessLoadVehicleRequest>
{
    private readonly IProcessLoadVehicleRepository repository;

    public SendToProcessHandler(IProcessLoadVehicleRepository repository)
    {
        this.repository = repository;
    }

    public override async Task ProcessRequest(ProcessLoadVehicleRequest request)
    {
        request.AddRecord(GetType().Name, "Send Plot vehicle data to process", RecordType.SetInformation);
        var result = repository.ProcessVehiclePlotData(request.MasterCode);
        request.StepRecords.LastOrDefault().OutputJson = $"{result}";

        if (result != 1)
        {
            request.CodResponse = "04";
            request.TxtResponse = "El proceso fue interrumpido.";
            return;
        }
        await sucessor?.ProcessRequest(request);
    }
}
