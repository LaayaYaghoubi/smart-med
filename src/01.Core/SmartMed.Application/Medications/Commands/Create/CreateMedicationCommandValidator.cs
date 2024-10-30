using FluentValidation;
using SmartMed.Application.Medications.Commands.Exceptions;
namespace SmartMed.Application.Medications.Commands.Create;

public class CreateMedicationCommandValidator : AbstractValidator<CreateMedicationCommand>
{
    public CreateMedicationCommandValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage(nameof(MedicationNameIsRequiredException))
            .Length(1,50).WithMessage(nameof(MedicationNameMustBeBetweenOneAndFiftyCharactersException));

        RuleFor(x => x.Quantity)
            .GreaterThan(0).WithMessage(nameof(QuantityMustBeGreaterThanZeroException));
    }
}