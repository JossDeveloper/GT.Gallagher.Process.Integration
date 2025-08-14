using Autofac;
using GT.Gallagher.Process.Integration.Application.Boundaries;
using GT.Gallagher.Process.Integration.WebApi.UseCases.Process.LoadClient;
using GT.Gallagher.Process.Integration.WebApi.UseCases.Process.LoadInstallment;
using GT.Gallagher.Process.Integration.WebApi.UseCases.Process.LoadInsured;
using GT.Gallagher.Process.Integration.WebApi.UseCases.Process.LoadMovement;
using GT.Gallagher.Process.Integration.WebApi.UseCases.Process.LoadPolicy;
using GT.Gallagher.Process.Integration.WebApi.UseCases.Process.LoadVehicle;
using GT.Gallagher.Process.Integration.WebApi.UseCases.Recurrent.ProcessPlot;
using GT.Gallagher.Process.Integration.WebApi.UseCases.Token;

namespace GT.Gallagher.Process.Integration.WebApi.Module;

public class WebapiModule : Autofac.Module
{
    protected override void Load(ContainerBuilder builder)
    {
        builder.RegisterType<TokenPresenter>().As<IOutputPort<Application.UseCase.Login.LoginResponse>>()
            .AsImplementedInterfaces().InstancePerLifetimeScope().AsSelf();

        builder.RegisterType<ProcessLoadClientPresenter>().As<IOutputPort<Application.UseCase.Process.LoadClient.ProcessLoadClientResponse>>()
            .AsImplementedInterfaces().InstancePerLifetimeScope().AsSelf();

        builder.RegisterType<ProcessLoadInstallmentPresenter>().As<IOutputPort<Application.UseCase.Process.LoadInstallment.ProcessLoadInstallmentResponse>>()
            .AsImplementedInterfaces().InstancePerLifetimeScope().AsSelf();

        builder.RegisterType<ProcessLoadInsuredPresenter>().As<IOutputPort<Application.UseCase.Process.LoadInsured.ProcessLoadInsuredResponse>>()
            .AsImplementedInterfaces().InstancePerLifetimeScope().AsSelf();

        builder.RegisterType<ProcessLoadMovementPresenter>().As<IOutputPort<Application.UseCase.Process.LoadMovement.ProcessLoadMovementResponse>>()
            .AsImplementedInterfaces().InstancePerLifetimeScope().AsSelf();

        builder.RegisterType<ProcessLoadPolicyPresenter>().As<IOutputPort<Application.UseCase.Process.LoadPolicy.ProcessLoadPolicyResponse>>()
            .AsImplementedInterfaces().InstancePerLifetimeScope().AsSelf();

        builder.RegisterType<ProcessLoadVehiclePresenter>().As<IOutputPort<Application.UseCase.Process.LoadVehicle.ProcessLoadVehicleResponse>>()
            .AsImplementedInterfaces().InstancePerLifetimeScope().AsSelf();

        builder.RegisterType<RecurrentPlotPresenter>().As<IOutputPort<Application.UseCase.Recurrent.ProcessPlot.RecurrentPlotResponse>>()
            .AsImplementedInterfaces().InstancePerLifetimeScope() .AsSelf();
    }
}
