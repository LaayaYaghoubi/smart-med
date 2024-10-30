using Microsoft.EntityFrameworkCore;

namespace SmartMed.Persistence.EF
{
    public sealed class EfReadDataContext : DbContext
    {
        public EfReadDataContext(DbContextOptions options) : base(options)
        {
            ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }

        public EfReadDataContext(string connectionString) :
            this(new DbContextOptionsBuilder().UseSqlServer(connectionString).Options)
        {
            ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(EfDataContext).Assembly);
        }
        
        public override int SaveChanges()
        {
            throw new InvalidOperationException("SaveChanges is not allowed on a read-only context.");
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            throw new InvalidOperationException("SaveChangesAsync is not allowed on a read-only context.");
        }
    }
}