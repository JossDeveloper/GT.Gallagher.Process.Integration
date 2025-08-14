using GT.Gallagher.Process.Integration.Application.Repository.Process;
using GT.Gallagher.Process.Integration.Application.UseCase.Handler;
using GT.Gallagher.Process.Integration.Domain.Enum;
using Newtonsoft.Json;

namespace GT.Gallagher.Process.Integration.Application.UseCase.Process.LoadPolicy.Handlers;

public class BuildContentHandler : Handler<ProcessLoadPolicyRequest>
{
    private readonly IProcessLoadPolicyRepository repository;

    public BuildContentHandler(IProcessLoadPolicyRepository repository)
    {
        this.repository = repository;
    }

    public override async Task ProcessRequest(ProcessLoadPolicyRequest request)
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
