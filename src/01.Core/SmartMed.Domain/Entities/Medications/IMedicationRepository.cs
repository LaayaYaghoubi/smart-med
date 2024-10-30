using SmartMed.Contracts.Interfaces;

namespace SmartMed.Domain.Entities.Medications;

public interface IMedicationRepository : IRepository
{
    void Add(Medication medication);
    Task<bool> IsDuplicate(string requestCode);
}