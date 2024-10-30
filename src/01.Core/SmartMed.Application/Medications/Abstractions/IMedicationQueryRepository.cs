using SmartMed.Application.Medications.Queries.GetMedications;
using SmartMed.Contracts.Interfaces;

namespace SmartMed.Application.Medications.Abstractions;

public interface IMedicationQueryRepository : IRepository
{
    Task<List<GetMedicationDto>> GetAllAsync();
}