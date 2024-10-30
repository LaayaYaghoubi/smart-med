using Microsoft.EntityFrameworkCore;
using SmartMed.Domain.Entities.Medications;

namespace SmartMed.Persistence.EF.Medications;

public class EfMedicationRepository : IMedicationRepository
{
    private readonly DbSet<Medication> _medications;

    public EfMedicationRepository(EfDataContext context)
    {
        _medications = context.Set<Medication>();
    }

    public void Add(Medication medication)
    {
        _medications.Add(medication);
    }

    public async Task<bool> IsDuplicate(string requestCode)
    {
        return await _medications.AnyAsync(m => m.Code.ToLower() == requestCode.ToLower());
    }
}