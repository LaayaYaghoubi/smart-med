using MediatR;
using SmartMed.Domain.Entities.Medications;

namespace SmartMed.Application.Medications.Commands.Create;

public record CreateMedicationCommand : IRequest
{
    public string Name { get; set; }
    public int Quantity { get; set; }
    public MedicationType Type { get; set; }
    public string Code { get; set; }
}