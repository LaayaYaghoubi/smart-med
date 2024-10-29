using Microsoft.EntityFrameworkCore;

namespace SmartMed.Persistence.EF;

public class EfDataContext : DbContext
{
    public EfDataContext(DbContextOptions options) : base(options)
    {
    }

    public EfDataContext(string connectionString) :
        this(new DbContextOptionsBuilder().UseSqlServer(connectionString).Options)
    {
    }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly
            (typeof(EfDataContext).Assembly);
    }
}