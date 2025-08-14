namespace GT.Gallagher.Process.Integration.Infrastructure.DataAccess.Entities.Common;

public class RepositoryServer : PrimaryProperties
{
    public string Description { get; private set; }
    public string Server { get; private set; }
    public string? User { get; private set; }
    public string? Password { get; private set; }
    public string? SshHostKey { get; private set; }
    public string? Root { get; private set; }
}
