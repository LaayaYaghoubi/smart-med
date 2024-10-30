using MediatR;

namespace SmartMed.Application.Medications.Queries.GetMedications;

public class GetMedicationQuery : IRequest<List<GetMedicationDto>>
{
}