namespace GT.Gallagher.Process.Integration.Domain.Token;

public class TokenValidateResponse
{
    public string User { get; private set; }
    public string Company { get => Environment.GetEnvironmentVariable("COMPANY") ?? "Gallagher"; }
    public string RoleName { get => "UserForToken"; }
    public string? Token { get; set; }
    public DateTime? Expires { get; set; }
    public int ExpirationTimeInMinutes { get; set; }
    public int ExpirationTimeInSeconds { get => (ExpirationTimeInMinutes * 60); }

    public TokenValidateResponse(string user)
    {
        User = user;
    }
}
