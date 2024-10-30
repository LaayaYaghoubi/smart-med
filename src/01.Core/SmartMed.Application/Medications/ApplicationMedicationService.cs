using SmartMed.Application.Medications.Contracts;
using SmartMed.Application.Medications.Contracts.Dto;
using SmartMed.Application.Medications.Exceptions;
using SmartMed.Contracts.Interfaces;
using SmartMed.Domain.Entities.Medications;

namespace SmartMed.Application.Medications;

public class ApplicationMedicationService : IMedicationService
{
    private readonly IMedicationRepository _medicationRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IDateTimeService _dateTimeService;

    public ApplicationMedicationService(IMedicationRepository medicationRepository, IUnitOfWork unitOfWork, IDateTimeService dateTimeService)
    {
        _medicationRepository = medicationRepository;
        _unitOfWork = unitOfWork;
        _dateTimeService = dateTimeService;
    }

    public async Task AddAsync(AddMedicationDto dto)
    {
        if(dto.Quantity <= 0)
            throw new QuantityMustBeGreaterThanZeroException();
        
        var isDuplicated = await _medicationRepository.IsCodeDuplicated(dto.Code);
        if(isDuplicated)
            throw new MedicationCodeIsDuplicated();
        
        var medication = new Medication
        {
            Name = dto.Name,
            Quantity = dto.Quantity,
            CreationDate = _dateTimeService.Now,
            Type = dto.Type,
            Code = dto.Code
        };
        _medicationRepository.Add(medication);
        await _unitOfWork.Complete();
    }

    public async Task DeleteAsync(int id)
    {
        var medication = await _medicationRepository.GetById(id);
        if(medication == null)
            throw new MedicationNotFoundException();
        
        _medicationRepository.Delete(medication);
        await _unitOfWork.Complete();
    }

    public async Task<List<GetMedicationDto>> GetAllAsync()
    {
        return await _medicationRepository.GetAll();
    }
}