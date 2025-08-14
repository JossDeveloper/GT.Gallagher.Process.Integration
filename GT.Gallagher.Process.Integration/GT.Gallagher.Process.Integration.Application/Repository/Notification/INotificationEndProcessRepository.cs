using GT.Gallagher.Process.Integration.Domain.GTService.Mail.Send;
using GT.Gallagher.Process.Integration.Domain.Notification;
using GT.Gallagher.Process.Integration.Domain.TPAService.Base;

namespace GT.Gallagher.Process.Integration.Application.Repository.Notification;

public interface INotificationEndProcessRepository
{
    NotificationEndProcess GetNotificationFromDb(Guid code);
    Task<(SuccessResponse?, BadResponse?)> SendNotificationEndProcess(MailInput mail, string token);
}
