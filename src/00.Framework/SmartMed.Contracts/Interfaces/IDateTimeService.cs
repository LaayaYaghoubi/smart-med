namespace SmartMed.Contracts.Interfaces;

public interface IDateTimeService : IService
{
    DateTime Now { get; }
    DateTime Today { get; }
}