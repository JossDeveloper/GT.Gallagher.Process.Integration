namespace GT.Gallagher.Process.Integration.Domain.GTService.Mail.Send;

public class Content
{
    public string Subject { get; set; }
    public string BodyName { get; set; }
    public List<Attachment>? Attachments { get; set; }

    public Content(string subject, string bodyName, List<Attachment>? attachments)
    {
        Subject = subject;
        BodyName = bodyName;
        Attachments = attachments;
    }
}