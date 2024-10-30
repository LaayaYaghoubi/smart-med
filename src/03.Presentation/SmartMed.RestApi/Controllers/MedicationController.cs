using Microsoft.AspNetCore.Mvc;
using SmartMed.Application.Medications.Contracts;
using SmartMed.Application.Medications.Contracts.Dto;

namespace SmartMed.RestApi.Controllers;

[ApiController]
[Route("api/v1/medication")]
public class MedicationController : ControllerBase
{
    private readonly IMedicationService _medicationService;

    public MedicationController(IMedicationService medicationService)
    {
        _medicationService = medicationService;
    }

    [HttpPost]
    public async Task Add([FromBody] AddMedicationDto dto)
    {
        await _medicationService.AddAsync(dto);
    }
    
    [HttpDelete("{id}")]
    public async Task Delete(int id)
    {
        await _medicationService.DeleteAsync(id);
    }
    
    [HttpGet]
    public async Task<List<GetMedicationDto>> GetAll()
    {
        return await _medicationService.GetAllAsync();
    }
}