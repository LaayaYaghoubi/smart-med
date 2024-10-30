using Microsoft.EntityFrameworkCore;
using SmartMed.Application.Medications.Contracts;
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

    public async Task<bool> IsCodeDuplicated(string code)
    {
        return await _medications.AnyAsync(med => med.Code.ToLower() == code.ToLower());
    }
}