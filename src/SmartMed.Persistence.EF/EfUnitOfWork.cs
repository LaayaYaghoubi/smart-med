using SmartMed.Contracts.Interfaces;

namespace SmartMed.Persistence.EF;

public class EfUnitOfWork : IUnitOfWork
{
    private readonly EfDataContext _dataContext;

    public EfUnitOfWork(EfDataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public async Task Begin()
    {
        await _dataContext.Database.BeginTransactionAsync();
    }

    public async Task Commit()
    {
        await _dataContext.SaveChangesAsync();
        await _dataContext.Database.CommitTransactionAsync();
    }

    public async Task Rollback()
    {
        await _dataContext.Database.RollbackTransactionAsync();
    }

    public async Task Complete()
    {
        await _dataContext.SaveChangesAsync();
    }

    public async Task CommitPartial()
    {
        await _dataContext.SaveChangesAsync();
    }
}