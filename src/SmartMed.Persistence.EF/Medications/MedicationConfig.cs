using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SmartMed.Domain.Entities.Medications;

namespace SmartMed.Persistence.EF.Medications;

public class MedicationConfig : IEntityTypeConfiguration<Medication>
{
    public void Configure(EntityTypeBuilder<Medication> _)
    {
        _.ToTable("Medications");
        _.HasKey(med => med.Id);
        _.Property(med => med.Id).ValueGeneratedOnAdd();
        _.Property(med => med.Name).HasMaxLength(50).IsRequired();
        _.Property(med => med.Code).HasMaxLength(30).IsRequired();
    }
}