namespace GT.Gallagher.Process.Integration.Domain.GTService.Mail.Send;

public class Receiver
{
    public List<string> To { get; set; }
    public List<string>? Cc { get; set; }
    public List<string>? Bcc { get; set; }

    public Receiver(List<string> to, List<string>? cc, List<string>? bcc)
    {
        To = to;
        Cc = cc;
        Bcc = bcc;
    }
}
