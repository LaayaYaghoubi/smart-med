using System.Reflection;
using Autofac;
using Autofac.Builder;
using Microsoft.EntityFrameworkCore;
using SmartMed.Contracts.Interfaces;

namespace SmartMed.Persistence.EF.Infrastructure;

public class PersistenceRegister : IPersistenceRegister
{
    private readonly ContainerBuilder _container;
    private IRegistrationBuilder<
        EfDataContext,
        ConcreteReflectionActivatorData,
        SingleRegistrationStyle> _efDataContextRegisterer;

    public PersistenceRegister(
        IPersistenceConfig config,
        ContainerBuilder container)
    {
        _container = container;
        _efDataContextRegisterer = _container.RegisterType<EfDataContext>()
            .WithParameter(
                "options",
                ((DbContextOptionsBuilder)new DbContextOptionsBuilder<EfDataContext>()
                    .UseSqlServer(config.ConnectionString)).Options);
    }

    public IPersistenceRegister WithEntityMapsAssembly(Assembly assembly)
    {
        _efDataContextRegisterer = _efDataContextRegisterer.WithParameter(
            "entityMapsAssembly", assembly);
        return this;
    }

    public void Register()
    {
        _efDataContextRegisterer
            .AsSelf().InstancePerLifetimeScope();

        _container.RegisterType<EfUnitOfWork>()
            .As<IUnitOfWork>()
            .InstancePerLifetimeScope();
    }
}