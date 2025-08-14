using GT.Gallagher.Process.Integration.Application.Repository.Process;
using GT.Gallagher.Process.Integration.Application.UseCase.Handler;
using GT.Gallagher.Process.Integration.Domain.Enum;
using Newtonsoft.Json;

namespace GT.Gallagher.Process.Integration.Application.UseCase.Process.LoadInstallment.Handlers;

public class ReadContentFileHandler : Handler<ProcessLoadInstallmentRequest>
{
    private readonly IProcessLoadInstallmentRepository repository;

    public ReadContentFileHandler(IProcessLoadInstallmentRepository repository)
    {
        this.repository = repository;
    }

    public override async Task ProcessRequest(ProcessLoadInstallmentRequest request)
    {
        request.AddRecord(GetType().Name, "Read Content File", RecordType.InternalBuild);
        request.FileLines = repository.ReadContentFile(request.Input.FileInput.Bytes);
        request.StepRecords.LastOrDefault().OutputJson = JsonConvert.SerializeObject(request.FileLines);

        if (!request.FileLines.Any())
        {
            request.CodResponse = "06";
            request.TxtResponse = "Archivo no contiene registros.";
            return;
        }
        request.FileLines.RemoveAll(s => s.Item1 == 0);

        await sucessor?.ProcessRequest(request);
    }
}
