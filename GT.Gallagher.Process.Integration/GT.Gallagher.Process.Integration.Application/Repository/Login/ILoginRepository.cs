namespace GT.Gallagher.Process.Integration.Application.Repository.Login;

public interface ILoginRepository
{
    bool ValidateLogin(string user, string pass);
}

