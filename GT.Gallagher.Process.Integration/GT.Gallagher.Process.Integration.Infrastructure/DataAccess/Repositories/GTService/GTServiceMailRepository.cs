using AutoMapper;
using GT.Gallagher.Process.Integration.Application.Repository.GTService.Mail;
using GT.Gallagher.Process.Integration.Domain.GTService.Mail.Send;
using GT.Gallagher.Process.Integration.Domain.TPAService.Base;
using GT.Gallagher.Process.Integration.Infrastructure.Helper;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using RestSharp;

namespace GT.Gallagher.Process.Integration.Infrastructure.DataAccess.Repositories.GTService;

public class GTServiceMailRepository : IGTServiceMailRepository
{
    private readonly IMapper mapper;

    public GTServiceMailRepository(IMapper mapper)
    {
        this.mapper = mapper;
    }

    public async Task<(SuccessResponse, BadResponse)> Send(MailInput mailInput, string token)
    {
        var opt = new JsonSerializerSettings() { ContractResolver = new CamelCasePropertyNamesContractResolver() };
        var request = UseService.MountRequest(Environment.GetEnvironmentVariable("GT_SERVICE_ENDPOINT_MAIL_SEND"), Method.Post);
            request.AddHeader("Authorization", $"Bearer {token}");
            request.AddParameter("application/json", JsonConvert.SerializeObject(mailInput, opt), ParameterType.RequestBody);

        var (successResponse, badResponse) = await UseService.GetTpaResponseAsync<Entities.TPAService.SuccessResponse, Entities.TPAService.BadResponse>(
            request, 
            Environment.GetEnvironmentVariable("GT_SERVICE_URL"), 
            int.Parse(Environment.GetEnvironmentVariable("GT_SERVICE_EXPIRATION_TIME")));

        return (mapper.Map<SuccessResponse>(successResponse), mapper.Map<BadResponse>(badResponse));
    }
}
