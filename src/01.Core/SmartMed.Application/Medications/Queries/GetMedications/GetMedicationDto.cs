using SmartMed.Domain.Entities.Medications;

namespace SmartMed.Application.Medications.Queries.GetMedications;

public record GetMedicationDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Quantity { get; set; }
    public MedicationType Type { get; set; }
}