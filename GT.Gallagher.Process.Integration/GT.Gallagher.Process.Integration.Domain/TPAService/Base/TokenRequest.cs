namespace GT.Gallagher.Process.Integration.Domain.TPAService.Base;

public class TokenRequest
{
    public string Username { get; private set; }
    public string Password { get; private set; }

    public TokenRequest(string username, string password)
    {
        Username=username;
        Password=password;
    }
}
