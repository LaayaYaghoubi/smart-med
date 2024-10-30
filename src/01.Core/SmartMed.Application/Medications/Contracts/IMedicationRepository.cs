using SmartMed.Application.Medications.Contracts.Dto;
using SmartMed.Contracts.Interfaces;
using SmartMed.Domain.Entities.Medications;

namespace SmartMed.Application.Medications.Contracts;

public interface IMedicationRepository : IRepository
{
    void Add(Medication medication);
    Task<bool> IsCodeDuplicated(string code);
    Task<Medication?> GetById(int id);
    void Delete(Medication medication);
    Task<List<GetMedicationDto>> GetAll();
}