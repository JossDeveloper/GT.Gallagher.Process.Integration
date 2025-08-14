using GT.Gallagher.Process.Integration.Application.Repository.Recurrent;
using GT.Gallagher.Process.Integration.Application.Repository.TPAService;
using GT.Gallagher.Process.Integration.Application.UseCase.Handler;
using GT.Gallagher.Process.Integration.Domain.Enum;
using Newtonsoft.Json;

namespace GT.Gallagher.Process.Integration.Application.UseCase.Recurrent.ProcessPlot.Handlers;

public class SendToProcessHandler : Handler<RecurrentPlotRequest>
{
    private readonly ITPAGenerateJWT generateJWT;
    private readonly IRecurrentPlotRepository repository;

    public SendToProcessHandler(ITPAGenerateJWT generateJWT, IRecurrentPlotRepository repository)
    {
        this.generateJWT = generateJWT;
        this.repository = repository;
    }

    public override async Task ProcessRequest(RecurrentPlotRequest request)
    {
        if (request.SftpFiles.Any())
        {
            var token = generateJWT.GenerateJsonWebToken(Environment.GetEnvironmentVariable("TPA_USER"));

            var plot = request.SftpFiles.FirstOrDefault();
            var endpoint = request.ScheduledProcesses.EndPoint ?? "";

            request.AddRecord(GetType().Name, "Send To Plot Feedback Service", RecordType.InternalService);
            var (successResponse, badResponse) = repository.SendToProcess(request.Input.UserId, plot, endpoint, token.Token);
            request.StepRecords.LastOrDefault().OutputJson = JsonConvert.SerializeObject(successResponse is null ? badResponse : successResponse);

            if (successResponse?.Output is not null)
                request.Output = successResponse.Output;

            if (badResponse is not null)
            {
                if (badResponse?.Details is not null)
                {
                    request.Details.AddRange(badResponse.Details);
                }
                request.CodResponse = "07";
                request.TxtResponse = badResponse.Title;
                return;
            }
            return;
        }
        request.CodResponse = "08";
        request.TxtResponse = "No se obtuvo información de archivos en repositorio.";

        await sucessor?.ProcessRequest(request);
    }
}
