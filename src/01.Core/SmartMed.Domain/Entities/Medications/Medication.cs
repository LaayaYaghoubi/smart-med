using SmartMed.Contracts.BaseClasses;

namespace SmartMed.Domain.Entities.Medications;

public class Medication : BaseEntity<int>
{
    public string Name { get; set; }
    public int Quantity { get; set; }
    public string Code { get; set; }
    public DateOnly CreationDate { get; set; }
    public MedicationType Type { get; set; }
}