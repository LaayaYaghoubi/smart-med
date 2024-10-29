using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using SmartMed.Application.Medications.Contracts;
using SmartMed.Domain.Entities.Medications;
using SmartMed.Test.Tools.Infrastructure.DataBaseConfig.Unit;
using SmartMed.Test.Tools.Medications.Create;

namespace SmartMed.Applications.Unit.Tests.Medications.Create;

public class AddMedicationTests : BusinessUnitTest
{
    private readonly IMedicationService _medicationService;

    public AddMedicationTests()
    {
        _medicationService = MedicationServiceFactory.Create(SetupContext);
    }

    [Fact]
    public async Task Add_Medication_adds_medication_properly()
    {
        var medication = AddMedicationDtoFactory.Create();

        await _medicationService.AddAsync(medication);

        var actual = await ReadContext.Set<Medication>().SingleAsync();
        actual.Name.Should().Be(medication.Name);
        actual.Quantity.Should().Be(medication.Quantity);
        actual.CreationDate.Should().Be(medication.CreationDate);
        actual.Type.Should().Be(medication.Type);
    }
}