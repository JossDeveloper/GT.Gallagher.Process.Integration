namespace GT.Gallagher.Process.Integration.Domain.GTService.Mail.Send;

public class ReplaceData
{
    public string Name { get; private set; }
    public string Value { get; private set; }

    public ReplaceData(string name, string value)
    {
        Name = name;
        Value = value;
    }
}
