namespace SmartMed.Persistence.EF.Infrastructure;

public class PersistenceConfig : IPersistenceConfig
{
    public string ConnectionString { get; set; } = default!;
}