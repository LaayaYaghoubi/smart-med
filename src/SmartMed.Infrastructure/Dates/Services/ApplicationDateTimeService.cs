using SmartMed.Contracts.Interfaces;

namespace SmartMed.Infrastructure.Dates.Services
{
    public class ApplicationDateTimeService : IDateTimeService
    {
        public DateTime Today => DateTime.UtcNow.Date;

        public DateTime Now => DateTime.UtcNow;
    }
}
