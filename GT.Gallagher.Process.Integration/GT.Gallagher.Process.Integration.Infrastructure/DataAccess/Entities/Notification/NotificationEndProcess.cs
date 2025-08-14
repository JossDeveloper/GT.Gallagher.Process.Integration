namespace GT.Gallagher.Process.Integration.Infrastructure.DataAccess.Entities.Notification;

public class NotificationEndProcess
{
    public string Subject { get; private set; }
    public string HtmlBody { get; private set; }
    public string EmailTo { get; private set; }
    public string EmailCc { get; private set; }
    public string EmailBcc { get; private set; }
}
