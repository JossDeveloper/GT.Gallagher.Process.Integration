using GT.Gallagher.Process.Integration.Application.Repository.Process;
using GT.Gallagher.Process.Integration.Application.UseCase.Handler;
using GT.Gallagher.Process.Integration.Domain.Enum;
using GT.Gallagher.Process.Integration.Domain.Process;

namespace GT.Gallagher.Process.Integration.Application.UseCase.Process.LoadInstallment.Handlers;

public class SaveProcessHandler : Handler<ProcessLoadInstallmentRequest>
{
    private readonly IProcessLoadInstallmentRepository repository;

    public SaveProcessHandler(IProcessLoadInstallmentRepository repository)
    {
        this.repository = repository;
    }

    public override async Task ProcessRequest(ProcessLoadInstallmentRequest request)
    {
        request.AddRecord(GetType().Name, "Save Process", RecordType.SetInformation);

        var result = repository.SaveProcessMaster(
            request.MasterCode,
            request.Input.UserId,
            request.Input.ProcessCode,
            request.Input.UniqueName,
            request.Input.FileInput.Name,
            Path.GetExtension(request.Input.FileInput.Name),
            request.ProcessLoadDetails,
            request.ProcessLoadDetails.Count);

        request.StepRecords.LastOrDefault().OutputJson = $"{result}";

        if (result != 1)
        {
            request.CodResponse = "04";
            request.TxtResponse = "No se pudo guardar el registro de detalles de carga.";
            return;
        }
        request.Output = new ProcessLoadOutput(
            request.MasterCode, 
            request.Input.FileInput.Name, 
            request.ProcessLoadDetails.Count);

        await sucessor?.ProcessRequest(request);
    }
}
