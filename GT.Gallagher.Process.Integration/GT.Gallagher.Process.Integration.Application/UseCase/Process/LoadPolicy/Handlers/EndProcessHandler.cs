using GT.Gallagher.Process.Integration.Application.Repository.Process;
using GT.Gallagher.Process.Integration.Application.UseCase.Handler;
using GT.Gallagher.Process.Integration.Domain.Enum;

namespace GT.Gallagher.Process.Integration.Application.UseCase.Process.LoadPolicy.Handlers;

public class EndProcessHandler : Handler<ProcessLoadPolicyRequest>
{
    private readonly IProcessLoadPolicyRepository repository;

    public EndProcessHandler(IProcessLoadPolicyRepository repository)
    {
        this.repository = repository;
    }

    public override async Task ProcessRequest(ProcessLoadPolicyRequest request)
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
