using SmartMed.Application.Medications.Contracts.Dto;
using SmartMed.Contracts.Interfaces;

namespace SmartMed.Application.Medications.Contracts;

public interface IMedicationService : IService
{
    Task AddAsync(AddMedicationDto dto);
    Task DeleteAsync(int id);
}