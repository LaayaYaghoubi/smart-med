using Microsoft.EntityFrameworkCore;
using SmartMed.Application.Medications.Abstractions;
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

    public async Task<bool> IsDuplicate(string code)
    {
        return await _medications.AnyAsync(m => m.Code.ToLower() == code.ToLower());
    }

    public async Task<Medication?> GetByIdAsync(int id)
    {
        return await _medications.FirstOrDefaultAsync(med=>med.Id == id);
    }

    public void Delete(Medication medication)
    {
        _medications.Remove(medication);
    }
}