namespace GT.Gallagher.Process.Integration.Domain.Common;

public class FileInput
{
    public string? Name { get; private set; }
    public byte[]? Bytes { get; private set; }
    public string? ContentType { get; private set; }

    public FileInput(string? name, byte[]? bytes, string? contentType)
    {
        Name = name;
        Bytes = bytes;
        ContentType = contentType;
    }
}
