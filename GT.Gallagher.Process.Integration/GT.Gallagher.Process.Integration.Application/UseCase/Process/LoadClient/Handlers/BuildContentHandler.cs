using GT.Gallagher.Process.Integration.Application.Repository.Process;
using GT.Gallagher.Process.Integration.Application.UseCase.Handler;
using GT.Gallagher.Process.Integration.Domain.Enum;
using Newtonsoft.Json;

namespace GT.Gallagher.Process.Integration.Application.UseCase.Process.LoadClient.Handlers;

public class BuildContentHandler : Handler<ProcessLoadClientRequest>
{
    private readonly IProcessLoadClientRepository repository;

    public BuildContentHandler(IProcessLoadClientRepository repository)
    {
        this.repository = repository;
    }

    public override async Task ProcessRequest(ProcessLoadClientRequest request)
    {
        request.AddRecord(GetType().Name, "Build Content File", RecordType.InternalBuild);
        request.ProcessLoadContents = repository.BuildContentFile(request.FileLines);
        request.StepRecords.LastOrDefault().OutputJson = JsonConvert.SerializeObject(request.FileLines);

        if (!request.ProcessLoadContents.Any())
        {
            request.CodResponse = "06";
            request.TxtResponse = "No se obtuvo información de registros. (mapeo)";
            return;
        }
        await sucessor?.ProcessRequest(request);
    }
}
