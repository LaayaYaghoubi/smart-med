using SmartMed.Application.Medications;
using SmartMed.Application.Medications.Contracts;
using SmartMed.Persistence.EF;
using SmartMed.Persistence.EF.Medications;

namespace SmartMed.Test.Tools.Medications.Create;

public static class MedicationServiceFactory
{
    public static IMedicationService Create(EfDataContext context)
    {
        return   new ApplicationMedicationService(new EfMedicationRepository(context), new EfUnitOfWork(context));
    }

  
}