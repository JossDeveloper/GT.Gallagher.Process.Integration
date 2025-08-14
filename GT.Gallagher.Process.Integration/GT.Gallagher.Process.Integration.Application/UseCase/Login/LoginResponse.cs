namespace GT.Gallagher.Process.Integration.Application.UseCase.Login;

public class LoginResponse
{
    public string Token { get; private set; }
    public int ExpirationTimeInSeconds { get; private set; }

    public LoginResponse(string token, int expirationTimeInSeconds)
    {
        Token = token;
        ExpirationTimeInSeconds = expirationTimeInSeconds;
    }
}

