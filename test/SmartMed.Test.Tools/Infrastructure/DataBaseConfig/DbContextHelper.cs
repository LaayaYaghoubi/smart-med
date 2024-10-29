using Microsoft.EntityFrameworkCore;

namespace SmartMed.Test.Tools.Infrastructure.DataBaseConfig;

public static class DbContextHelper
{
    public static void Manipulate<TDbContext>(
        this TDbContext dbContext,
        Action<TDbContext> manipulate)
        where TDbContext : DbContext
    {
        manipulate(dbContext);
        dbContext.SaveChanges();
    }

    public static void Save<TDbContext, TEntity>(
        this TDbContext dbContext,
        TEntity entity)
        where TDbContext : DbContext
        where TEntity : class
    {
        dbContext.Add(entity);
        dbContext.SaveChanges();
    }

    public static void SaveRange<TDbContext, TEntity>(
        this TDbContext dbContext,
        params TEntity[] entities)
        where TDbContext : DbContext
        where TEntity : class, new()
    {
        entities.ForEach(entity => dbContext.Add(entity));
        dbContext.SaveChanges();
    }

    private static void ForEach<T>(this IEnumerable<T> source, Action<T> action)
    {
        using var enumerator = source.GetEnumerator();
        while (enumerator.MoveNext())
        {
            action(enumerator.Current);
        }
    }
}