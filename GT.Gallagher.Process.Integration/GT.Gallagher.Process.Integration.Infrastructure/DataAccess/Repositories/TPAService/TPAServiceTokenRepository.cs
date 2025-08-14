using AutoMapper;
using GT.Gallagher.Process.Integration.Application.Repository.TPAService;
using GT.Gallagher.Process.Integration.Domain.TPAService.Base;
using GT.Gallagher.Process.Integration.Infrastructure.Helper;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using RestSharp;

namespace GT.Gallagher.Process.Integration.Infrastructure.DataAccess.Repositories.TPAService;

public class TPAServiceTokenRepository : ITPAServiceTokenRepository
{
    private readonly IMapper mapper;

    public TPAServiceTokenRepository(IMapper mapper)
    {
        this.mapper=mapper;
    }

    public async Task<TokenResponse> Get(TokenRequest tokenRequest, string endPoint, string url, int maxTimeOutInSeconds)
    {
        var opt = new JsonSerializerSettings() { ContractResolver = new CamelCasePropertyNamesContractResolver() };        
        var request = UseService.MountRequest(endPoint, Method.Post);
            request.AddParameter("application/json", JsonConvert.SerializeObject(tokenRequest, opt), ParameterType.RequestBody);

        var (successResponse, badResponse) = await UseService.GetTpaResponseAsync<Entities.TPAService.TokenResponse, Entities.TPAService.BadResponse>(request, url, maxTimeOutInSeconds);

        if (successResponse is null)
            throw new ApplicationException(" No se pudo autenticar con servicio externo.");

        return mapper.Map<TokenResponse>(successResponse);
    }
}
