using Autofac;
using AutoMapper;
using AutoMapper.Extensions.ExpressionMapping;
using GlobalTpa.Extension.Serilog.Contract;
using GlobalTpa.Extension.Serilog.Implementation;

namespace GT.Gallagher.Process.Integration.Infrastructure.Modules;

public class InfrastructureModule : Module
{
    protected override void Load(ContainerBuilder builder)
    {
        builder.RegisterAssemblyTypes(typeof(InfrastructureException).Assembly)
            .Where(x => (x.Namespace ?? string.Empty).Contains("Repositories"))
            .AsImplementedInterfaces()
            .AsSelf().InstancePerLifetimeScope();

        Mapper(builder);

        builder.RegisterType<LogRequest>().As<ILogRequest>().InstancePerLifetimeScope().AsSelf();
    }

    private void Mapper(ContainerBuilder builder)
    {
        builder.RegisterAssemblyTypes(typeof(InfrastructureException).Assembly)
           .Where(t => (t.Namespace ?? string.Empty).Contains("DataAccess") && typeof(Profile).IsAssignableFrom(t) && !t.IsAbstract && t.IsPublic)
           .As<Profile>();

        builder.Register(c => new MapperConfiguration(cfg =>
        {
            foreach (var profile in c.Resolve<IEnumerable<Profile>>())
                cfg.AddProfile(profile);

            cfg.AddExpressionMapping();
        })).AsSelf().SingleInstance();

        builder.Register(c => c.Resolve<MapperConfiguration>()
            .CreateMapper(c.Resolve))
            .As<IMapper>()
            .InstancePerLifetimeScope();
    }
}

