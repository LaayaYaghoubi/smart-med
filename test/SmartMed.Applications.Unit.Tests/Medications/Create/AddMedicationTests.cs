using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using SmartMed.Application.Medications.Contracts;
using SmartMed.Application.Medications.Exceptions;
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
    public async Task Add_should_adds_Medication_medication_properly()
    {
        var medication = AddMedicationDtoFactory.Create();

        await _medicationService.AddAsync(medication);

        var actual = await ReadContext.Set<Medication>().SingleAsync();
        actual.Name.Should().Be(medication.Name);
        actual.Quantity.Should().Be(medication.Quantity);
        actual.CreationDate.Should().Be(medication.CreationDate);
        actual.Type.Should().Be(medication.Type);
    }
    
    [Theory]
    [InlineData(-1)]
    [InlineData(0)]
    public async Task Add_should_throw_exception_if_quantity_is_less_than_or_equal_to_zero(int quantity)
    {
        var medication = AddMedicationDtoFactory.Create();
        medication.Quantity = quantity;

        var act = async () => await _medicationService.AddAsync(medication);

        await act.Should().ThrowExactlyAsync<QuantityMustBeGreaterThanZeroException>();
    }
}