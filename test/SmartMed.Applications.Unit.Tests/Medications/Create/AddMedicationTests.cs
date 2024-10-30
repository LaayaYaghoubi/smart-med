using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using SmartMed.Application.Medications.Commands.Create;
using SmartMed.Application.Medications.Commands.Exceptions;
using SmartMed.Domain.Entities.Medications;
using SmartMed.Test.Tools.Infrastructure.DataBaseConfig.Unit;
using SmartMed.Test.Tools.Medications;
using SmartMed.Test.Tools.Medications.Create;

namespace SmartMed.Applications.Unit.Tests.Medications.Create;

public class AddMedicationTests : BusinessUnitTest
{
    private readonly CreateMedicationCommandHandler _createMedicationCommandHandler;
    private readonly DateTime _fakeDateTimeNow = DateTime.UtcNow;

    public AddMedicationTests()
    {
        _createMedicationCommandHandler= CreateMedicationCommandHandlerFactory.Create(SetupContext, _fakeDateTimeNow);
    }

    [Fact]
    public async Task Add_should_adds_Medication_medication_properly()
    {
        var command = new CreateMedicationCommand
        {
            Name = "Medication",
            Quantity = 10,
            Type = MedicationType.Liquid,
            Code = "123456"
        };

        await _createMedicationCommandHandler.Handle(command, default);

        var actual = await ReadContext.Set<Medication>().SingleAsync();
        actual.Name.Should().Be(command.Name);
        actual.Quantity.Should().Be(command.Quantity);
        actual.CreationDate.Should().Be(_fakeDateTimeNow);
        actual.Type.Should().Be(command.Type);
    }
    
    [Fact]
    public async Task Add_should_throw_exception_if_medication_code_is_duplicated()
    {
        var medication = new MedicationBuilder().Build();
        Save(medication);
        var command = new CreateMedicationCommand
        {
            Name = "Medication",
            Quantity = 10,
            Type = MedicationType.Liquid,
            Code = medication.Code
        };
    
        var act =()=> _createMedicationCommandHandler.Handle(command,default);
    
        await act.Should().ThrowExactlyAsync<MedicationCodeIsDuplicatedException>();
    }
}