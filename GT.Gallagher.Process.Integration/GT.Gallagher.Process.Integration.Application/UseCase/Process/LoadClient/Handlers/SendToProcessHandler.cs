using GT.Gallagher.Process.Integration.Application.Repository.Process;
using GT.Gallagher.Process.Integration.Application.UseCase.Handler;
using GT.Gallagher.Process.Integration.Domain.Enum;

namespace GT.Gallagher.Process.Integration.Application.UseCase.Process.LoadClient.Handlers;

public class SendToProcessHandler : Handler<ProcessLoadClientRequest>
{
    private readonly IProcessLoadClientRepository repository;

    public SendToProcessHandler(IProcessLoadClientRepository repository)
    {
        this.repository = repository;
    }

    public override async Task ProcessRequest(ProcessLoadClientRequest request)
    {
        request.AddRecord(GetType().Name, "Send Plot client data to process", RecordType.SetInformation);
        var result = repository.ProcessClientPlotData(request.MasterCode);
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
