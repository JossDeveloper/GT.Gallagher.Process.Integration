using GT.Gallagher.Process.Integration.Application.Repository.Notification;
using GT.Gallagher.Process.Integration.Application.Repository.Process;
using GT.Gallagher.Process.Integration.Application.Repository.TPAService;
using GT.Gallagher.Process.Integration.Application.UseCase.Handler;
using GT.Gallagher.Process.Integration.Domain.Enum;
using GT.Gallagher.Process.Integration.Domain.GTService.Mail.Send;
using GT.Gallagher.Process.Integration.Domain.TPAService.Base;
using Newtonsoft.Json;

namespace GT.Gallagher.Process.Integration.Application.UseCase.Process.LoadInsured.Handlers;

public class SendNotificationHandler : Handler<ProcessLoadInsuredRequest>
{
    private readonly ITPAServiceTokenRepository tokenRepository;
    private readonly INotificationEndProcessRepository notificationRepository;
    private readonly IProcessLoadInsuredRepository processLoadInsuredRepository;

    public SendNotificationHandler(ITPAServiceTokenRepository tokenRepository, INotificationEndProcessRepository notificationRepository, IProcessLoadInsuredRepository processLoadInsuredRepository)
    {
        this.tokenRepository = tokenRepository;
        this.notificationRepository = notificationRepository;
        this.processLoadInsuredRepository = processLoadInsuredRepository;
    }

    public override async Task ProcessRequest(ProcessLoadInsuredRequest request)
    {
        request.AddRecord(GetType().Name, "Generate Excel Bytes", RecordType.InternalBuild);
        byte[] excelAttach = processLoadInsuredRepository.GenerateExcelToAttach(request.MasterDetailsFeedBack);
        request.StepRecords.LastOrDefault().OutputJson = "Successful generation.";

        string username = Environment.GetEnvironmentVariable("GT_SERVICE_USERNAME");
        string password = Environment.GetEnvironmentVariable("GT_SERVICE_PASSWORD");
        string endpoint = Environment.GetEnvironmentVariable("GT_SERVICE_ENDPOINT_TOKEN_LOGIN");
        string url = Environment.GetEnvironmentVariable("GT_SERVICE_URL");
        var codeNotification = Environment.GetEnvironmentVariable("CODE_NOTIFICATION_INSURED");
        int expirationTime = int.Parse(Environment.GetEnvironmentVariable("GT_SERVICE_EXPIRATION_TIME"));
        string subject = "";
        string body = "";
        string filename = Path.GetFileNameWithoutExtension(request.Input.FileInput.Name);
        List<string> toEmailList = null;
        List<string> ccEmailList = null;
        List<string> bccEmailList = null;

        if (Guid.TryParse(codeNotification, out Guid code))
        {
            var notification = notificationRepository.GetNotificationFromDb(code);
            var yyyymmdd_day = DateTime.Now.ToString("yyyyMMdd");
            var yyyymmdd_hms = DateTime.Now.ToString("yyyyMMdd_HHmmss");

            body = notification.HtmlBody;
            subject = notification.Subject;
            subject = subject.Replace("[#YYYYMMDD]", yyyymmdd_day);
            filename = $"{filename}_{yyyymmdd_hms}_Feedback";

            request.FeedBack = $"{filename}.xlsx";
            request.AddRecord(GetType().Name, "Put Excel Bytes in sftp", RecordType.InternalBuild);
            processLoadInsuredRepository.PutSftpFilesHistory(request.RepositoryServer, request.FeedBack, excelAttach);
            request.StepRecords.LastOrDefault().OutputJson = "Successful generation.";

            if (!string.IsNullOrEmpty(notification.EmailTo))
                toEmailList = notification.EmailTo.Split(';').ToList();
            if (!string.IsNullOrEmpty(notification.EmailCc))
                ccEmailList = notification.EmailCc.Split(';').ToList();
            if (!string.IsNullOrEmpty(notification.EmailBcc))
                bccEmailList = notification.EmailBcc.Split(';').ToList();

            var attachments = new List<Attachment>
            {
                new Attachment(AttachedType.xlsx, filename, Convert.ToBase64String(excelAttach))
            };

            var replaceData = new List<ReplaceData>
            {
                new ReplaceData("#Fecha", yyyymmdd_day),
                new ReplaceData("#NombreArchivoTrama", request.Input.FileInput.Name),
                new ReplaceData("#CantidadRegistrosProcesados", request.ProcessLoadContents.Count.ToString()),
                new ReplaceData("#CantidadRegistrosExitosos", request.MasterDetailsFeedBack.Count(s => s.ESTADO == "OK").ToString()),
                new ReplaceData("#CantidadRegistrosObservados", request.MasterDetailsFeedBack.Count(s => s.ESTADO == "OBSERVADO").ToString())
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

            await sucessor?.ProcessRequest(request);
        }
    }
}
