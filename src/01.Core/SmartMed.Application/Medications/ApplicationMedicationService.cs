using SmartMed.Application.Medications.Contracts;
using SmartMed.Application.Medications.Contracts.Dto;
using SmartMed.Contracts.Interfaces;
using SmartMed.Domain.Entities.Medications;

namespace SmartMed.Application.Medications;

public class ApplicationMedicationService : IMedicationService
{
    private readonly IMedicationRepository _medicationRepository;
    private readonly IUnitOfWork _unitOfWork;

    public ApplicationMedicationService(IMedicationRepository medicationRepository, IUnitOfWork unitOfWork)
    {
        _medicationRepository = medicationRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task AddAsync(AddMedicationDto dto)
    {
        var medication = new Medication
        {
            Name = dto.Name,
            Quantity = dto.Quantity,
            CreationDate = dto.CreationDate,
            Type = dto.Type,
            Code = dto.Code
        };
        _medicationRepository.Add(medication);
        await _unitOfWork.Complete();
    }
}