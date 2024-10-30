using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using SmartMed.Application.Medications.Contracts;
using SmartMed.Application.Medications.Exceptions;
using SmartMed.Domain.Entities.Medications;
using SmartMed.Test.Tools.Infrastructure.DataBaseConfig.Unit;
using SmartMed.Test.Tools.Medications;
using SmartMed.Test.Tools.Medications.Create;

namespace SmartMed.Applications.Unit.Tests.Medications.Delete;

public class DeleteMedicationTests : BusinessUnitTest
{
    private readonly IMedicationService _medicationService;

    public DeleteMedicationTests()
    {
        _medicationService = MedicationServiceFactory.Create(SetupContext);
    }
    
    [Fact]
    public async Task Delete_should_delete_medication_properly()
    {
        var medication = new MedicationBuilder().Build();
        Save(medication);

        await _medicationService.DeleteAsync(medication.Id);

        var actual = await ReadContext.Set<Medication>().SingleOrDefaultAsync();
        actual.Should().BeNull();
    }
    
    [Fact]
    public async Task Delete_should_throw_exception_if_medication_not_found()
    {
        var act = () => _medicationService.DeleteAsync(1);

        await act.Should().ThrowExactlyAsync<MedicationNotFoundException>();
    }
}