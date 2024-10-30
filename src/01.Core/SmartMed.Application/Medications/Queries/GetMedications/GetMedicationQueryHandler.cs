using MediatR;
using SmartMed.Application.Medications.Abstractions;
using SmartMed.Domain.Entities.Medications;

namespace SmartMed.Application.Medications.Queries.GetMedications;

public class GetMedicationQueryHandler : IRequestHandler<GetMedicationQuery,List<GetMedicationDto>>
{
    private readonly IMedicationQueryRepository _medicationQueryRepository;

    public GetMedicationQueryHandler(IMedicationQueryRepository medicationQueryRepository)
    {
        _medicationQueryRepository = medicationQueryRepository;
    }

    public async Task<List<GetMedicationDto>> Handle(GetMedicationQuery request, CancellationToken cancellationToken)
    {
        return await _medicationQueryRepository.GetAllAsync();
    }
}

