using Microsoft.EntityFrameworkCore;
using SmartMed.Application.Medications.Contracts;
using SmartMed.Application.Medications.Contracts.Dto;
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

    public async Task<Medication?> GetById(int id)
    {
        return await _medications.FirstOrDefaultAsync(med=>med.Id == id);
    }

    public void Delete(Medication medication)
    {
        _medications.Remove(medication);
    }

    public async Task<List<GetMedicationDto>> GetAll()
    {
       return await _medications.Select(med => new GetMedicationDto
        {
            Id = med.Id,
            Name = med.Name,
            Quantity = med.Quantity,
            Type = med.Type,
            Code = med.Code
        }).ToListAsync();
    }
}