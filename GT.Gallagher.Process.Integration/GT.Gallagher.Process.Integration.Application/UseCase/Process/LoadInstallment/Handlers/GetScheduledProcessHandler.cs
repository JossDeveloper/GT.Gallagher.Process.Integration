using GT.Gallagher.Process.Integration.Application.Repository.Common;
using GT.Gallagher.Process.Integration.Application.UseCase.Handler;
using GT.Gallagher.Process.Integration.Domain.Enum;
using Newtonsoft.Json;

namespace GT.Gallagher.Process.Integration.Application.UseCase.Process.LoadInstallment.Handlers;

public class GetScheduledProcessHandler : Handler<ProcessLoadInstallmentRequest>
{
    private readonly ICommonRepository commonRepository;

    public GetScheduledProcessHandler(ICommonRepository commonRepository)
    {
        this.commonRepository = commonRepository;
    }

    public override async Task ProcessRequest(ProcessLoadInstallmentRequest request)
    {
        request.AddRecord(GetType().Name, "Get Scheduled Process - Scheduled", RecordType.GetInformation);
        request.ScheduledProcesses = commonRepository.GetScheduledProcesses(Guid.Parse(Environment.GetEnvironmentVariable("CODE_SCHEDULED_INSTALLMENT")), 0);
        request.StepRecords.LastOrDefault().OutputJson = JsonConvert.SerializeObject(request.ScheduledProcesses);

        if (request.ScheduledProcesses is null)
        {
            request.CodResponse = "03";
            request.TxtResponse = "No se pudo obtener información del proceso programado.";
            return;
        }

        request.AddRecord(GetType().Name, "Get Scheduled Process - Repository", RecordType.GetInformation);
        request.RepositoryServer = commonRepository.GetRepositorySftp(request.ScheduledProcesses.RepositoryCode);
        request.StepRecords.LastOrDefault().OutputJson = JsonConvert.SerializeObject(request.RepositoryServer);

        if (request.RepositoryServer is null)
        {
            request.CodResponse = "03";
            request.TxtResponse = "No se pudo obtener información del repositorio SFTP.";
            return;
        }

        await sucessor?.ProcessRequest(request);
    }
}
