using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using SmartMed.Application.Medications.Contracts;
using SmartMed.Application.Medications.Contracts.Dto;
using SmartMed.Application.Medications.Exceptions;
using SmartMed.Contracts.Interfaces;
using SmartMed.Domain.Entities.Medications;
using SmartMed.Test.Tools.Infrastructure.DataBaseConfig.Unit;
using SmartMed.Test.Tools.Medications;
using SmartMed.Test.Tools.Medications.Create;

namespace SmartMed.Applications.Unit.Tests.Medications.Create;

public class AddMedicationTests : BusinessUnitTest
{
    private readonly IMedicationService _medicationService;
    private readonly DateTime fakeDateTimeNow = DateTime.UtcNow;

    public AddMedicationTests()
    {
        _medicationService = MedicationServiceFactory.Create(SetupContext,fakeDateTimeNow);
    }

    [Fact]
    public async Task Add_should_adds_Medication_medication_properly()
    {
        var medication = AddMedicationDtoFactory.Create();

        await _medicationService.AddAsync(medication);

        var actual = await ReadContext.Set<Medication>().SingleAsync();
        actual.Name.Should().Be(medication.Name);
        actual.Quantity.Should().Be(medication.Quantity);
        actual.CreationDate.Should().Be(fakeDateTimeNow);
        actual.Type.Should().Be(medication.Type);
    }

    [Theory]
    [InlineData(-1)]
    [InlineData(0)]
    public async Task Add_should_throw_exception_if_quantity_is_less_than_or_equal_to_zero(int quantity)
    {
        var medication = AddMedicationDtoFactory.Create();
        medication.Quantity = quantity;

        var act = () => _medicationService.AddAsync(medication);

        await act.Should().ThrowExactlyAsync<QuantityMustBeGreaterThanZeroException>();
    }

    [Fact]
    public async Task Add_should_throw_exception_if_medication_code_is_duplicated()
    {
        var medication = new MedicationBuilder().Build();
        Save(medication);
        var dto = new AddMedicationDto
        {
            Name = medication.Name,
            Code = medication.Code,
            Quantity = 10,
            Type = MedicationType.Liquid
        };

        var act = () => _medicationService.AddAsync(dto);

        await act.Should().ThrowExactlyAsync<MedicationCodeIsDuplicated>();
    }
}