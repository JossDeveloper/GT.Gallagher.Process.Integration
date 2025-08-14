using GT.Gallagher.Process.Integration.Application.Repository.Process;
using GT.Gallagher.Process.Integration.Application.UseCase.Handler;
using GT.Gallagher.Process.Integration.Domain.Enum;
using Newtonsoft.Json;

namespace GT.Gallagher.Process.Integration.Application.UseCase.Process.LoadVehicle.Handlers;

public class GetFeedBackHandler : Handler<ProcessLoadVehicleRequest>
{
    private readonly IProcessLoadVehicleRepository repository;

    public GetFeedBackHandler(IProcessLoadVehicleRepository repository)
    {
        this.repository = repository;
    }

    public override async Task ProcessRequest(ProcessLoadVehicleRequest request)
    {
        request.AddRecord(GetType().Name, "Get Master Details", RecordType.GetInformation);
        request.MasterDetailsFeedBack = repository.GetMasterDetailsFeedBack(request.MasterCode);
        request.StepRecords.LastOrDefault().OutputJson = JsonConvert.SerializeObject(request.MasterDetailsFeedBack);

        await sucessor?.ProcessRequest(request);
    }
}
