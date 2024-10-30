using FluentAssertions;
using SmartMed.Application.Medications.Queries.GetMedications;
using SmartMed.Persistence.EF.Medications;
using SmartMed.Test.Tools.Infrastructure.DataBaseConfig;
using SmartMed.Test.Tools.Infrastructure.DataBaseConfig.Unit;
using SmartMed.Test.Tools.Medications;

namespace SmartMed.Applications.Unit.Tests.Medications.Queries.GetMedications;

public class GetMedicationTests : BusinessUnitTest
{
    private readonly GetMedicationQueryHandler _sut;

    public GetMedicationTests()
    {
        _sut = new GetMedicationQueryHandler(new EfMedicationQueryRepository(ReadContext));
    }

    [Fact]
    public async Task GetMedications_should_return_all_medications_count_properly()
    {
        var medication =
            new MedicationBuilder().Build();
        DbContext.Save(medication);
        var medication2 =
            new MedicationBuilder().Build();
        DbContext.Save(medication2);
        var medication3 =
            new MedicationBuilder().Build();
        DbContext.Save(medication3);

        var actual = await _sut.Handle(new GetMedicationQuery(), default);

        actual.Count.Should().Be(3);
    }
    
    [Fact]
    public async Task GetMedications_should_return_all_medications_data_properly()
    {
        var medication =
            new MedicationBuilder().Build();
        DbContext.Save(medication);
        
        var actual = await _sut.Handle(new GetMedicationQuery(), default);

     var actualMed = actual.Single();
        actualMed.Id.Should().Be(medication.Id);
        actualMed.Name.Should().Be(medication.Name);
        actualMed.Quantity.Should().Be(medication.Quantity);
        actualMed.Type.Should().Be(medication.Type);
    }
}