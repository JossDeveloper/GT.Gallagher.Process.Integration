using GT.Gallagher.Process.Integration.Application.Repository.Process;
using GT.Gallagher.Process.Integration.Application.UseCase.Handler;
using GT.Gallagher.Process.Integration.Domain.Enum;
using Newtonsoft.Json;

namespace GT.Gallagher.Process.Integration.Application.UseCase.Process.LoadClient.Handlers;

public class ReadContentFileHandler : Handler<ProcessLoadClientRequest>
{
    private readonly IProcessLoadClientRepository repository;

    public ReadContentFileHandler(IProcessLoadClientRepository repository)
    {
        this.repository = repository;
    }

    public override async Task ProcessRequest(ProcessLoadClientRequest request)
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
