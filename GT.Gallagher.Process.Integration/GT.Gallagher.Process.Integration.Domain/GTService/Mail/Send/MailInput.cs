namespace GT.Gallagher.Process.Integration.Domain.GTService.Mail.Send;

public class MailInput
{
    public string Company { get; set; }
    public Receiver Receiver { get; set; }
    public Content Content { get; set; }
    public List<ReplaceData>? DataToReplace { get; set; }

    public MailInput(string company, Receiver receiver, Content content, List<ReplaceData>? dataToReplace)
    {
        Company = company;
        Receiver = receiver;
        Content = content;
        DataToReplace = dataToReplace;
    }
}
