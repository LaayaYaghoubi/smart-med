using FluentValidation.TestHelper;
using SmartMed.Application.Medications.Commands.Create;
using SmartMed.Application.Medications.Commands.Exceptions;

namespace SmartMed.Applications.Unit.Tests.Medications.Create;

public class CreateMedicationCommandValidatorTests
{
    private readonly CreateMedicationCommandValidator _sut = new();

    [Fact]
    public void Should_Pass_Validation_When_Command_Is_Valid()
    {
       
        var command = new CreateMedicationCommand
        {
            Name = "Aspirin",
            Quantity = 10,
        };
       
        var result = _sut.TestValidate(command);

       
        result.ShouldNotHaveAnyValidationErrors();
    }
    

    [Theory]
    [InlineData(0)]
    [InlineData(-1)]
    public void Should_Fail_Validation_When_Quantity_Is_Negative_Or_Zero(int quantity)
    {
       
        var command = new CreateMedicationCommand
        {
            Name = "Aspirin",
            Quantity = quantity
        };

       
        var result = _sut.TestValidate(command);

       
        result.ShouldHaveValidationErrorFor(c => c.Quantity)
            .WithErrorMessage(nameof(QuantityMustBeGreaterThanZeroException));
    }
    
    [Fact]
    public void Should_Fail_Validation_When_Name_Length_Is_Not_Between_1_And_50()
    {
        var command = new CreateMedicationCommand
        {
            Name = new string('A', 51),
            Quantity = 453
        };
       
        var result = _sut.TestValidate(command);

       
        result.ShouldHaveValidationErrorFor(c => c.Name)
            .WithErrorMessage(nameof(MedicationNameMustBeBetweenOneAndFiftyCharactersException));
    }
    
    [Fact]
    public void Should_Fail_Validation_When_Name_Is_Empty()
    {
        var command = new CreateMedicationCommand
        {
            Name = "",
            Quantity = 453
        };
       
        var result = _sut.TestValidate(command);

       
        result.ShouldHaveValidationErrorFor(c => c.Name)
            .WithErrorMessage(nameof(MedicationNameIsRequiredException));
    }
    
}