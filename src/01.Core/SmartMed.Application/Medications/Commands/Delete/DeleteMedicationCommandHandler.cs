using MediatR;
using SmartMed.Application.Medications.Abstractions;
using SmartMed.Application.Medications.Commands.Exceptions;
using SmartMed.Contracts.Interfaces;

namespace SmartMed.Application.Medications.Commands.Delete;

public class DeleteMedicationCommandHandler : IRequestHandler<DeleteMedicationCommand>
{
    private readonly IMedicationRepository _medicationRepository;
    private readonly IUnitOfWork _unitOfWork;

    public DeleteMedicationCommandHandler(
        IMedicationRepository medicationRepository,
        IUnitOfWork unitOfWork)
    {
        _medicationRepository = medicationRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(DeleteMedicationCommand request, CancellationToken cancellationToken)
    {
       var medication = await _medicationRepository.GetByIdAsync(request.Id);
         if (medication == null)
                throw new MedicationNotFoundException();
         
         _medicationRepository.Delete(medication);
         await _unitOfWork.Complete();

    }
}