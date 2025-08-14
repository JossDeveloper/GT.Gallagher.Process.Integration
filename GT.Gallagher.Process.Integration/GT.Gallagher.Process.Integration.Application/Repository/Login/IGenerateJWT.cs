using GT.Gallagher.Process.Integration.Domain.Token;

namespace GT.Gallagher.Process.Integration.Application.Repository.Login;

public interface IGenerateJWT
{
    TokenValidateResponse GenerateJsonWebToken(string user);
}

