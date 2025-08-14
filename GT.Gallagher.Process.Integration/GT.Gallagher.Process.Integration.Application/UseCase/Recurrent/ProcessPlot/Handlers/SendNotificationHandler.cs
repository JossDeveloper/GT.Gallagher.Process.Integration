using GT.Gallagher.Process.Integration.Application.Repository.Notification;
using GT.Gallagher.Process.Integration.Application.Repository.TPAService;
using GT.Gallagher.Process.Integration.Application.UseCase.Handler;
using GT.Gallagher.Process.Integration.Domain.Enum;
using GT.Gallagher.Process.Integration.Domain.GTService.Mail.Send;
using GT.Gallagher.Process.Integration.Domain.TPAService.Base;
using Newtonsoft.Json;

namespace GT.Gallagher.Process.Integration.Application.UseCase.Recurrent.ProcessPlot.Handlers;

public class SendNotificationHandler : Handler<RecurrentPlotRequest>
{
    private readonly ITPAServiceTokenRepository tokenRepository;
    private readonly INotificationEndProcessRepository notificationRepository;

    public SendNotificationHandler(ITPAServiceTokenRepository tokenRepository, INotificationEndProcessRepository notificationRepository)
    {
        this.tokenRepository = tokenRepository;
        this.notificationRepository = notificationRepository;
    }

    public override async Task ProcessRequest(RecurrentPlotRequest request)
    {
        string username = Environment.GetEnvironmentVariable("GT_SERVICE_USERNAME");
        string password = Environment.GetEnvironmentVariable("GT_SERVICE_PASSWORD");
        string endpoint = Environment.GetEnvironmentVariable("GT_SERVICE_ENDPOINT_TOKEN_LOGIN");
        string url = Environment.GetEnvironmentVariable("GT_SERVICE_URL");
        var codeNotification = Environment.GetEnvironmentVariable("CODE_NOTIFICATION_EMPTY_REPOSITORY");
        int expirationTime = int.Parse(Environment.GetEnvironmentVariable("GT_SERVICE_EXPIRATION_TIME"));
        string subject = "";
        string body = "";
        List<string> toEmailList = null;
        List<string> ccEmailList = null;
        List<string> bccEmailList = null;

        if (Guid.TryParse(codeNotification, out Guid code))
        {
            string proceso = GetProcessName(request.Input.ProcessId);

            var notification = notificationRepository.GetNotificationFromDb(code);
            var yyyymmdd_day = DateTime.Now.ToString("yyyyMMdd");

            body = notification.HtmlBody;
            subject = notification.Subject;
            subject = subject
                .Replace("[#YYYYMMDD]", yyyymmdd_day)
                .Replace("[#PROCESO]", proceso);

            if (!string.IsNullOrEmpty(notification.EmailTo))
                toEmailList = notification.EmailTo.Split(';').ToList();
            if (!string.IsNullOrEmpty(notification.EmailCc))
                ccEmailList = notification.EmailCc.Split(';').ToList();
            if (!string.IsNullOrEmpty(notification.EmailBcc))
                bccEmailList = notification.EmailBcc.Split(';').ToList();

            var attachments = new List<Attachment>();
            var replaceData = new List<ReplaceData>
            {
                new ReplaceData("#Fecha", yyyymmdd_day),
                new ReplaceData("#Proceso", proceso)
            };
            
            var token = await tokenRepository.Get(new TokenRequest(username, password), endpoint, url, expirationTime);
            
            var objRequest = new MailInput(
                Environment.GetEnvironmentVariable("COMPANY"),
                new Receiver(toEmailList, ccEmailList, bccEmailList),
                new Content(subject, body, attachments),
                replaceData);

            request.AddRecord(GetType().Name, "Send to Notification Service", RecordType.InternalService);
            var (successResponse, badResponse) = notificationRepository.SendNotificationEndProcess(objRequest, token.Access_token).GetAwaiter().GetResult();
            request.StepRecords.LastOrDefault().OutputJson = JsonConvert.SerializeObject(successResponse is null ? badResponse : successResponse);
        }
    }

    private string GetProcessName(int cod)
    {
        switch (cod)
        {
            case 606:
                return "CLIENTES";
            case 739:
                return "POLIZAS";
            case 740:
                return "VEHICULOS";
            case 889:
                return "CUOTAS";
            case 890:
                return "ASEGURADOS";
            case 891:
                return "MOVIMIENTOS";
        }
        return "";
    }
}
