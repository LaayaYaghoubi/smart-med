using SmartMed.Persistence.EF;

namespace SmartMed.Test.Tools.Infrastructure.DataBaseConfig.Unit;

public class BusinessUnitTest
{
    protected EfDataContext DbContext { get; set; }
    protected EfDataContext SetupContext { get; set; }
    protected EfDataContext ReadContext { get; set; }


    protected BusinessUnitTest(string? tenantId = null)
    {
        var db = CreateDatabase();

      

        DbContext = db.CreateDataContext<EfDataContext>();
        SetupContext = db.CreateDataContext
            <EfDataContext>();
        ReadContext = db.CreateDataContext<EfDataContext>();
    }

    protected EFInMemoryDatabase CreateDatabase()
    {
        return new EFInMemoryDatabase();
    }
    protected void Save<T>(T entity)
    {
        if (entity != null)
        {
            DbContext.Manipulate(_ => _.Add(entity));
        }
    }

    public void Save<T>(params T[] entities)
    {
        foreach (var item in entities)
            DbContext.Manipulate(_ => _.Add(item!));
    }

    public void Save()
    {
        DbContext.SaveChanges();
    }
}