namespace GT.Gallagher.Process.Integration.Domain.Common;

public class SftpFile
{
    public Guid ProcessCode { get; private set; }
    public Guid UniqueName { get; private set; }
    public string Name { get; private set; }
    public string Extension { get => Path.GetExtension(Name); }

    public SftpFile(string name)
    {
        ProcessCode = Guid.NewGuid();
        UniqueName = Guid.NewGuid();
        Name = name;
    }
}
