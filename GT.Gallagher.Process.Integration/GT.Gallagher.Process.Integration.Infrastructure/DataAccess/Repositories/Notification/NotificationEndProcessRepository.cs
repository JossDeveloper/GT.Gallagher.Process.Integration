using AutoMapper;
using GT.Gallagher.Process.Integration.Application.Repository.Notification;
using GT.Gallagher.Process.Integration.Domain.GTService.Mail.Send;
using GT.Gallagher.Process.Integration.Domain.Notification;
using GT.Gallagher.Process.Integration.Domain.TPAService.Base;
using GT.Gallagher.Process.Integration.Infrastructure.External;
using GT.Gallagher.Process.Integration.Infrastructure.Helper;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using RestSharp;
using System.Data;

using EntNotificacion = GT.Gallagher.Process.Integration.Infrastructure.DataAccess.Entities.Notification;
using EntTpaService = GT.Gallagher.Process.Integration.Infrastructure.DataAccess.Entities.TPAService;

namespace GT.Gallagher.Process.Integration.Infrastructure.DataAccess.Repositories.Notification;

public class NotificationEndProcessRepository : INotificationEndProcessRepository
{
    private readonly IMapper _mapper;

    public NotificationEndProcessRepository(IMapper mapper)
    {
        _mapper = mapper;
    }

    public NotificationEndProcess GetNotificationFromDb(Guid code)
    {
        using (var context = new Context())
        {
            var parameters = new List<SqlParameter>();
                parameters.Add(new SqlParameter() { SqlDbType = SqlDbType.UniqueIdentifier, ParameterName = "@Code", Direction = ParameterDirection.Input, Value = code });

            var result = context.Set<EntNotificacion.NotificationEndProcess>()
                .FromSqlRaw(@"exec ObtenerSw_Notificacion @Code", parameters.ToArray())
                .ToList().FirstOrDefault();
            return _mapper.Map<NotificationEndProcess>(result);
        }
    }

    public async Task<(SuccessResponse?, BadResponse?)> SendNotificationEndProcess(MailInput mail, string token)
    {
        var opt = new JsonSerializerSettings() { ContractResolver = new CamelCasePropertyNamesContractResolver() };
        var request = UseService.MountRequest(TpaConfig.EndPointMailSend, Method.Post);
            request.AddHeader("Authorization", $"Bearer {token}");
            request.AddParameter("application/json", JsonConvert.SerializeObject(mail, opt), ParameterType.RequestBody);

        var (successResponse, badResponse) = await UseService.GetTpaResponseAsync<EntTpaService.SuccessResponse, EntTpaService.BadResponse>(request, TpaConfig.UrlGtService, TpaConfig.ExpirationTime);

        return (_mapper.Map<SuccessResponse>(successResponse), _mapper.Map<BadResponse>(badResponse));
    }
}
