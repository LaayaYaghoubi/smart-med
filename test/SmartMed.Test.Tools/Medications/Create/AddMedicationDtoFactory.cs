using SmartMed.Application.Medications.Contracts.Dto;
using SmartMed.Domain.Entities.Medications;

namespace SmartMed.Test.Tools.Medications.Create;

public static class AddMedicationDtoFactory
{
    public static AddMedicationDto Create()
    {
        return new  AddMedicationDto
        {
            Name = "Medication 1",
            Quantity = 10,
            Type = MedicationType.Tablet,
            Code = "43534"
        };
    }
}