namespace GT.Gallagher.Process.Integration.Domain.Common;

public class RepositoryServer
{
    public int Id { get; private set; }
    public Guid Code { get; private set; }
    public string Description { get; private set; }
    public string Server { get; private set; }
    public string? User { get; private set; }
    public string? Password { get; private set; }
    public string? SshHostKey { get; private set; }
    public string? Root { get; private set; }

    public RepositoryServer(int id, Guid code, string description, string server, string? user, string? password, string? sshHostKey, string? root)
    {
        Id = id;
        Code = code;
        Description = description;
        Server = server;
        User = user;
        Password = password;
        SshHostKey = sshHostKey;
        Root = root;
    }
}
