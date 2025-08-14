using GT.Gallagher.Process.Integration.Application.Repository.Process;
using GT.Gallagher.Process.Integration.Application.UseCase.Handler;
using GT.Gallagher.Process.Integration.Domain.Enum;

namespace GT.Gallagher.Process.Integration.Application.UseCase.Process.LoadInsured.Handlers;

public class SendToProcessHandler : Handler<ProcessLoadInsuredRequest>
{
    private readonly IProcessLoadInsuredRepository repository;

    public SendToProcessHandler(IProcessLoadInsuredRepository repository)
    {
        this.repository = repository;
    }

    public override async Task ProcessRequest(ProcessLoadInsuredRequest request)
    {
        request.AddRecord(GetType().Name, "Send Plot insured data to process", RecordType.SetInformation);
        var result = repository.ProcessInsuredPlotData(request.MasterCode);
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
