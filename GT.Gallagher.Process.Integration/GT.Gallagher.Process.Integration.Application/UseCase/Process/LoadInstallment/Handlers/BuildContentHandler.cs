using GT.Gallagher.Process.Integration.Application.Repository.Process;
using GT.Gallagher.Process.Integration.Application.UseCase.Handler;
using GT.Gallagher.Process.Integration.Domain.Enum;
using Newtonsoft.Json;

namespace GT.Gallagher.Process.Integration.Application.UseCase.Process.LoadInstallment.Handlers;

public class BuildContentHandler : Handler<ProcessLoadInstallmentRequest>
{
    private readonly IProcessLoadInstallmentRepository repository;

    public BuildContentHandler(IProcessLoadInstallmentRepository repository)
    {
        this.repository = repository;
    }

    public override async Task ProcessRequest(ProcessLoadInstallmentRequest request)
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
