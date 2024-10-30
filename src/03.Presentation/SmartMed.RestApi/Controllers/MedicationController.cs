using MediatR;
using Microsoft.AspNetCore.Mvc;
using SmartMed.Application.Medications.Commands.Create;
using SmartMed.Application.Medications.Queries.GetMedications;

namespace SmartMed.RestApi.Controllers;

[ApiController]
[Route("api/v1/medication")]
public class MedicationController : ControllerBase
{
    private readonly ISender _mediator;

    public MedicationController(ISender mediator)
    {
        _mediator = mediator;
    }
    
    [HttpPost]
    public async Task Add([FromBody] CreateMedicationCommand command)
    {
        await _mediator.Send(command);
    }
    
    [HttpGet]
    public async Task<List<GetMedicationDto>> GetAll()
    {
        return await _mediator.Send(new GetMedicationQuery());
    }
}