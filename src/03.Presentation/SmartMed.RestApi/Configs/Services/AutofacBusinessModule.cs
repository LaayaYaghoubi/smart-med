using Autofac;
using SmartMed.Application.Medications.Commands.Create;
using SmartMed.Contracts.Interfaces;
using SmartMed.Infrastructure.Dates.Services;
using SmartMed.Persistence.EF;
using SmartMed.Persistence.EF.Infrastructure;

namespace SmartMed.RestApi.Configs.Services;

public class AutofacBusinessModule : Module
{
    private readonly IPersistenceConfig _persistenceConfig;
    private const string ConnectionStringKey = "connectionString";

    public AutofacBusinessModule(IConfiguration configuration)
    {
        _persistenceConfig =
            SmartMedPersistence.BuildPersistenceConfig(configuration);
    }

    protected override void Load(ContainerBuilder container)
    {
        var serviceAssembly = typeof(CreateMedicationCommandHandler).Assembly;
        var persistentAssembly = typeof(EfUnitOfWork).Assembly;


        container.RegisterAssemblyTypes(
                serviceAssembly,
                persistentAssembly)
            .AssignableTo<IService>()
            .AsImplementedInterfaces()
            .InstancePerLifetimeScope();

        container.RegisterAssemblyTypes(persistentAssembly, serviceAssembly)
            .AssignableTo<IRepository>()
            .AsImplementedInterfaces()
            .InstancePerLifetimeScope();


        container.RegisterType<EfDataContext>()
            .WithParameter(
                ConnectionStringKey, _persistenceConfig.ConnectionString)
            .AsSelf()
            .InstancePerLifetimeScope();
        
        container.RegisterType<ApplicationDateTimeService>()
            .As<IDateTimeService>()
            .SingleInstance();

        base.Load(container);
    }
}