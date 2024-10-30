using SmartMed.Domain.Entities.Medications;

namespace SmartMed.Test.Tools.Medications;

public class MedicationBuilder
{
    private readonly Medication _medication;
    
    public MedicationBuilder()
    {
        _medication = new Medication
        {
            Name = "Medication 1",
            Quantity = 10,
            CreationDate = new DateTime(2021, 10, 10),
            Type = MedicationType.Tablet,
            Code = "43534"
        };
    }
    
    public MedicationBuilder WithName(string name)
    {
        _medication.Name = name;
        return this;
    }
    
    public MedicationBuilder WithQuantity(int quantity)
    {
        _medication.Quantity = quantity;
        return this;
    }
    
    public MedicationBuilder WithCode(string code)
    {
        _medication.Code = code;
        return this;
    }
    
    public MedicationBuilder WithCreationDate(DateTime creationDate)
    {
        _medication.CreationDate = creationDate;
        return this;
    }
    
    public MedicationBuilder WithType(MedicationType type)
    {
        _medication.Type = type;
        return this;
    }
    
    public Medication Build()
    {
        return _medication;
    }
}