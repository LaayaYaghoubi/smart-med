namespace SmartMed.Contracts.Interfaces;

public interface IUnitOfWork : IService
{
    Task Begin();
    Task Commit();
    Task Rollback();
    Task CommitPartial();
    Task Complete();
}