namespace GT.Gallagher.Process.Integration.Application.UseCase.Login;

public class LoginRequest
{
    public string User { get; private set; }
    public string Pass { get; private set; }

    public LoginRequest(string user, string pass)
    {
        User = user;
        Pass = pass;
    }
}

