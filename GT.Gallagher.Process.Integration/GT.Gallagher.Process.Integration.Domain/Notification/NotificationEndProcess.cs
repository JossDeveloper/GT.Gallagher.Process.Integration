namespace GT.Gallagher.Process.Integration.Domain.Notification;

public class NotificationEndProcess
{
    public string Subject { get; private set; }
    public string HtmlBody { get; private set; }
    public string EmailTo { get; private set; }
    public string EmailCc { get; private set; }
    public string EmailBcc { get; private set; }

    public NotificationEndProcess(string subject, string htmlBody, string emailTo, string emailCc, string emailBcc)
    {
        Subject = subject;
        HtmlBody = htmlBody;
        EmailTo = emailTo;
        EmailCc = emailCc;
        EmailBcc = emailBcc;
    }
}
