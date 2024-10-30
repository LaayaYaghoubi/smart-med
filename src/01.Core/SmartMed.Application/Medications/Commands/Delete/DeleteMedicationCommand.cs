using MediatR;

namespace SmartMed.Application.Medications.Commands.Delete;

public record DeleteMedicationCommand(int Id) : IRequest
{
    
}