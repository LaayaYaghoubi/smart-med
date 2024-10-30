using SmartMed.Contracts.Interfaces;
using SmartMed.Domain.Entities.Medications;

namespace SmartMed.Application.Medications.Abstractions;

public interface IMedicationRepository : IRepository
{
    void Add(Medication medication);
    Task<bool> IsDuplicate(string requestCode);
}