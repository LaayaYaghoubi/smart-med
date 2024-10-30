using FluentAssertions;
using SmartMed.Application.Medications.Contracts;
using SmartMed.Test.Tools.Infrastructure.DataBaseConfig.Unit;
using SmartMed.Test.Tools.Medications;
using SmartMed.Test.Tools.Medications.Create;

namespace SmartMed.Applications.Unit.Tests.Medications.Get;

public class GetAllMedicationTests : BusinessUnitTest
{
    private readonly IMedicationService _medicationService;

    public GetAllMedicationTests()
    {
        _medicationService = MedicationServiceFactory.Create(SetupContext);
    }
    
    [Fact]
    public async Task GetAll_should_return_medication_count_properly()
    {
        var medication =
            new MedicationBuilder().Build();
        Save(medication);
        var medication2 =
            new MedicationBuilder().Build();
        Save(medication2);
        var medication3 =
            new MedicationBuilder().Build();
        Save(medication3);
        
        var actual = await _medicationService.GetAllAsync();

      actual.Count.Should().Be(3);
    }
    

    [Fact]
    public async Task GetAll_should_return_medication_date_properly()
    {
        var medication =
            new MedicationBuilder().Build();
        Save(medication);

        var actual = await _medicationService.GetAllAsync();

        var actualMed = actual.Single();
        actualMed.Name.Should().Be(medication.Name);
        actualMed.Quantity.Should().Be(medication.Quantity);
        actualMed.Type.Should().Be(medication.Type);
        actualMed.Code.Should().Be(medication.Code);
        actualMed.Id.Should().Be(medication.Id);
    }
}