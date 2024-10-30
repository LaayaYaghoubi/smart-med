using Moq;
using SmartMed.Application.Medications.Commands.Create;
using SmartMed.Contracts.Interfaces;
using SmartMed.Persistence.EF;
using SmartMed.Persistence.EF.Medications;

namespace SmartMed.Test.Tools.Medications.Create;

public static class CreateMedicationCommandHandlerFactory
{
    public static CreateMedicationCommandHandler Create(EfDataContext context, DateTime fakeDateTimeNow)
   
    {
        var mock = new Mock<IDateTimeService>();
        mock.Setup(dateTimeService => dateTimeService.Now).Returns(fakeDateTimeNow);
        
        return new CreateMedicationCommandHandler(new EfMedicationRepository(context),
            new EfUnitOfWork(context),mock.Object);
    }
}