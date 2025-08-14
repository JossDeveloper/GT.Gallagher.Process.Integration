using GT.Gallagher.Process.Integration.Application.Repository.Process;
using GT.Gallagher.Process.Integration.Application.UseCase.Handler;
using GT.Gallagher.Process.Integration.Domain.Enum;

namespace GT.Gallagher.Process.Integration.Application.UseCase.Process.LoadInstallment.Handlers;

public class SendToProcessHandler : Handler<ProcessLoadInstallmentRequest>
{
    private readonly IProcessLoadInstallmentRepository repository;

    public SendToProcessHandler(IProcessLoadInstallmentRepository repository)
    {
        this.repository = repository;
    }

    public override async Task ProcessRequest(ProcessLoadInstallmentRequest request)
    {
        request.AddRecord(GetType().Name, "Send Plot installment data to process", RecordType.SetInformation);
        var result = repository.ProcessInstallmentPlotData(request.MasterCode);
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
