using SmartMed.Domain.Entities.Medications;

namespace SmartMed.Application.Medications.Contracts.Dto;

public record AddMedicationDto
{
    public string Name { get; set; }
    public int Quantity { get; set; }
    public MedicationType Type { get; set; }
    public string Code { get; set; }
}