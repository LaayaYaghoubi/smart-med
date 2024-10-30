using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using SmartMed.Application.Medications.Commands.Delete;
using SmartMed.Application.Medications.Commands.Exceptions;
using SmartMed.Domain.Entities.Medications;
using SmartMed.Test.Tools.Infrastructure.DataBaseConfig.Unit;
using SmartMed.Test.Tools.Medications;
using SmartMed.Test.Tools.Medications.Delete;

namespace SmartMed.Applications.Unit.Tests.Medications.Commands.Delete;

public class DeleteMedicationTests : BusinessUnitTest
{
    private readonly DeleteMedicationCommandHandler _sut;

    public DeleteMedicationTests()
    {
        _sut = DeleteMedicationCommandHandlerFactory.Create(SetupContext);
    }

    [Fact]
    public async Task Delete_should_delete_medication_properly()
    {
        var medication = new MedicationBuilder().Build();
        Save(medication);
        var command = new DeleteMedicationCommand(medication.Id);

        await _sut.Handle(command, default);

        var actual = await ReadContext.Set<Medication>().SingleOrDefaultAsync();
        actual.Should().BeNull();
    }

    [Fact]
    public async Task Delete_should_throw_exception_if_medication_not_found()
    {
        var command = new DeleteMedicationCommand(1);

        var act = () => _sut.Handle(command, default);

        await act.Should().ThrowExactlyAsync<MedicationNotFoundException>();
    }
}