using GT.Gallagher.Process.Integration.Domain.TPAService.Base;

namespace GT.Gallagher.Process.Integration.Application.Repository.TPAService;

public interface ITPAServiceTokenRepository
{
    Task<TokenResponse> Get(TokenRequest tokenRequest, string endPoint, string url, int maxTimeOutInSeconds);
}
