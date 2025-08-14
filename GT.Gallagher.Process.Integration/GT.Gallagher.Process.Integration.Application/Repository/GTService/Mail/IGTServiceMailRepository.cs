using GT.Gallagher.Process.Integration.Domain.GTService.Mail.Send;
using GT.Gallagher.Process.Integration.Domain.TPAService.Base;

namespace GT.Gallagher.Process.Integration.Application.Repository.GTService.Mail;

public interface IGTServiceMailRepository
{
    Task<(SuccessResponse, BadResponse)> Send(MailInput mailInput, string token);
}
