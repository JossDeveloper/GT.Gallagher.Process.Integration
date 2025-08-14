using GT.Gallagher.Process.Integration.Domain.Enum;

namespace GT.Gallagher.Process.Integration.Domain.GTService.Mail.Send;

public class Attachment
{
    public AttachedType Extension { get; set; }
    public string Name { get; set; }
    public string FileContent { get; set; }

    public Attachment(AttachedType extension, string name, string fileContent)
    {
        Extension = extension;
        Name = name;
        FileContent = fileContent;
    }
}
