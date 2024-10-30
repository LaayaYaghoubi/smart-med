using Microsoft.EntityFrameworkCore;
using SmartMed.Application.Medications.Abstractions;
using SmartMed.Application.Medications.Queries.GetMedications;
using SmartMed.Domain.Entities.Medications;

namespace SmartMed.Persistence.EF.Medications;

public class EfMedicationQueryRepository : IMedicationQueryRepository
{
    private readonly DbSet<Medication> _medications;

    public EfMedicationQueryRepository(EfReadDataContext readContext)
    {
        _medications = readContext.Set<Medication>();
    }

    public async Task<List<GetMedicationDto>> GetAllAsync()
    {
      return await _medications.Select(_ => new GetMedicationDto
        {
            Id = _.Id,
            Name = _.Name,
            Quantity = _.Quantity,
            Type = _.Type
        }).ToListAsync();
    }
}