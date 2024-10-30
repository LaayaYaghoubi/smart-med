using MediatR;
using SmartMed.Application.Medications.Commands.Exceptions;
using SmartMed.Contracts.Interfaces;
using SmartMed.Domain.Entities.Medications;

namespace SmartMed.Application.Medications.Commands.Create;

public class CreateMedicationCommandHandler : IRequestHandler<CreateMedicationCommand>
{
    private readonly IMedicationRepository _medicationRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IDateTimeService _dateTimeService;

    public CreateMedicationCommandHandler(IMedicationRepository medicationRepository, IUnitOfWork unitOfWork,
        IDateTimeService dateTimeService)
    {
        _medicationRepository = medicationRepository;
        _unitOfWork = unitOfWork;
        _dateTimeService = dateTimeService;
    }

    public async Task Handle(CreateMedicationCommand request, CancellationToken cancellationToken)
    {
        var isDuplicate = await _medicationRepository.IsDuplicate(request.Code);
        if (isDuplicate)
        {
            throw new MedicationCodeIsDuplicatedException();
        }
        var medication = new Medication
        {
            Name = request.Name,
            Quantity = request.Quantity,
            Type = request.Type,
            Code = request.Code,
            CreationDate = _dateTimeService.Now
        };
        
        _medicationRepository.Add(medication);
        await _unitOfWork.Complete();
    }
}