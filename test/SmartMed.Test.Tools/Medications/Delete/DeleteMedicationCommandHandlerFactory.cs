using SmartMed.Application.Medications.Commands.Delete;
using SmartMed.Persistence.EF;
using SmartMed.Persistence.EF.Medications;

namespace SmartMed.Test.Tools.Medications.Delete;

public static class DeleteMedicationCommandHandlerFactory
{
    public static DeleteMedicationCommandHandler Create(EfDataContext context)
    {
        return new DeleteMedicationCommandHandler(new EfMedicationRepository(context), new EfUnitOfWork(context));
    }
}