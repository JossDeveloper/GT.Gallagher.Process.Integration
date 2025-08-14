using GT.Gallagher.Process.Integration.Domain.Token;

namespace GT.Gallagher.Process.Integration.Application.Repository.TPAService;

public interface ITPAGenerateJWT
{
    TokenValidateResponse GenerateJsonWebToken(string user);
}
