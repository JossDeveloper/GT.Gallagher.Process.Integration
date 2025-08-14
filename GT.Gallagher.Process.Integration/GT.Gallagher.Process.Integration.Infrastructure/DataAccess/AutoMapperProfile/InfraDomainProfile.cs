using AutoMapper;
using GT.Gallagher.Process.Integration.Domain.GTService.Mail.Send;

namespace GT.Gallagher.Process.Integration.Infrastructure.DataAccess.AutoMapperProfile;

public class InfraDomainProfile : Profile
{
    public InfraDomainProfile()
    {
        CreateMap<Entities.ProblemDetail, Domain.Base.ProblemDetail>().ReverseMap();

        CreateMap<Entities.Common.ScheduledProcesses, Domain.Common.ScheduledProcesses>().ReverseMap();
        CreateMap<Entities.Common.RepositoryServer, Domain.Common.RepositoryServer>().ReverseMap();
        CreateMap<Entities.Common.MasterDetailsOutput, Domain.Common.MasterDetailsOutput>().ReverseMap();

        CreateMap<Entities.Records.Record, Domain.Records.Record>().ReverseMap();
        CreateMap<Entities.Records.StepRecord, Domain.Records.StepRecord>().ReverseMap();
        
        CreateMap<Entities.TPAService.SuccessResponse, Domain.TPAService.Base.SuccessResponse>().ReverseMap();
        CreateMap<Entities.TPAService.BadResponse, Domain.TPAService.Base.BadResponse>().ReverseMap();
        CreateMap<Entities.TPAService.TokenResponse, Domain.TPAService.Base.TokenResponse>().ReverseMap();
        
        CreateMap<Entities.Notification.NotificationEndProcess, Domain.Notification.NotificationEndProcess>().ReverseMap();
        CreateMap<Entities.Notification.ReplaceData, ReplaceData>().ReverseMap();

        CreateMap<Domain.Process.LoadClient.ProcessLoadClient, Entities.Process.LoadClient.ProcessLoadClient>().ReverseMap();
        CreateMap<Domain.Process.LoadClient.ProcessLoadClientFeedBack, Entities.Process.LoadClient.ProcessLoadClientFeedBack>().ReverseMap();
        CreateMap<Domain.Process.LoadInstallment.ProcessLoadInstallment, Entities.Process.LoadInstallment.ProcessLoadInstallment>().ReverseMap();
        CreateMap<Domain.Process.LoadInstallment.ProcessLoadInstallmentFeedBack, Entities.Process.LoadInstallment.ProcessLoadInstallmentFeedBack>().ReverseMap();
        CreateMap<Domain.Process.LoadInsured.ProcessLoadInsured, Entities.Process.LoadInsured.ProcessLoadInsured>().ReverseMap();
        CreateMap<Domain.Process.LoadInsured.ProcessLoadInsuredFeedBack, Entities.Process.LoadInsured.ProcessLoadInsuredFeedBack>().ReverseMap();
        CreateMap<Domain.Process.LoadMovement.ProcessLoadMovement, Entities.Process.LoadMovement.ProcessLoadMovement>().ReverseMap();
        CreateMap<Domain.Process.LoadMovement.ProcessLoadMovementFeedBack, Entities.Process.LoadMovement.ProcessLoadMovementFeedBack>().ReverseMap();
        CreateMap<Domain.Process.LoadPolicy.ProcessLoadPolicy, Entities.Process.LoadPolicy.ProcessLoadPolicy>().ReverseMap();
        CreateMap<Domain.Process.LoadPolicy.ProcessLoadPolicyFeedBack, Entities.Process.LoadPolicy.ProcessLoadPolicyFeedBack>().ReverseMap();
        CreateMap<Domain.Process.LoadVehicle.ProcessLoadVehicle, Entities.Process.LoadVehicle.ProcessLoadVehicle>().ReverseMap();
        CreateMap<Domain.Process.LoadVehicle.ProcessLoadVehicleFeedBack, Entities.Process.LoadVehicle.ProcessLoadVehicleFeedBack>().ReverseMap();

        CreateMap<Domain.Gallagher.Process.ServiceProcessLoadResponse, Entities.Gallagher.Process.ServiceProcessLoadResponse>().ReverseMap();
        CreateMap<Domain.Process.ProcessLoadOutput, Entities.Gallagher.Process.ProcessLoadOutput>().ReverseMap();
    }
}
