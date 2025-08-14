using GT.Gallagher.Process.Integration.Application.Repository.Login;

namespace GT.Gallagher.Process.Integration.Infrastructure.DataAccess.Repositories;

public class LoginRepository : ILoginRepository
{
    public bool ValidateLogin(string user, string pass)
    {
        var _user = Environment.GetEnvironmentVariable("USER");
        var _pass = Environment.GetEnvironmentVariable("PASS");

        if (user != _user || pass != _pass)
            return false;

        return true;
    }
}

