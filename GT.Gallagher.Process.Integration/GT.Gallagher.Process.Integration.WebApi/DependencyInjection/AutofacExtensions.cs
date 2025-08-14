using Autofac;
using GT.Gallagher.Process.Integration.Infrastructure.Modules;
using GT.Gallagher.Process.Integration.WebApi.Module;

namespace GT.Gallagher.Process.Integration.WebApi.DependencyInjection;

public static class AutofacExtensions
{
    public static ContainerBuilder AddAutofacRegistration(this ContainerBuilder builder)
    {
        builder.RegisterModule<ApplicationModule>();
        builder.RegisterModule<InfrastructureModule>();
        builder.RegisterModule<WebapiModule>();

        return builder;
    }
}

