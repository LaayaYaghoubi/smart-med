using System.Reflection;

namespace SmartMed.Persistence.EF.Infrastructure;

public interface IPersistenceRegister
{
    IPersistenceRegister WithEntityMapsAssembly(Assembly assembly);
    void Register();
}
