using SmartMed.Contracts.Interfaces;
using SmartMed.Domain.Entities.Medications;

namespace SmartMed.Application.Medications.Contracts;

public interface IMedicationRepository : IRepository
{
    void Add(Medication medication);
}