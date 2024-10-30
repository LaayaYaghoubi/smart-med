using Moq;
using SmartMed.Application.Medications;
using SmartMed.Application.Medications.Contracts;
using SmartMed.Contracts.Interfaces;
using SmartMed.Persistence.EF;
using SmartMed.Persistence.EF.Medications;

namespace SmartMed.Test.Tools.Medications.Create;

public static class MedicationServiceFactory
{
    public static IMedicationService Create(EfDataContext context, DateTime? fakeDateTime = null)
    {
        var dateTimeService = new Mock<IDateTimeService>();
        dateTimeService.Setup(_ => _.Now)
            .Returns(fakeDateTime ?? DateTime.UtcNow);
        
        return   new ApplicationMedicationService(
            new EfMedicationRepository(context),
            new EfUnitOfWork(context),
            dateTimeService.Object);
        
    }

  
}