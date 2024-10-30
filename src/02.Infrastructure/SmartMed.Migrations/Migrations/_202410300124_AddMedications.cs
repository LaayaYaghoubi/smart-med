using FluentMigrator;

namespace SmartMed.Migrations.Migrations;
[Migration(202410300124)]
public class _202410300124_AddMedications : Migration
{
    public override void Up()
    {
        Create.Table("Medications")
            .WithColumn("Id").AsInt32().PrimaryKey().Identity().NotNullable()
            .WithColumn("Name").AsString(50).NotNullable()
            .WithColumn("Quantity").AsInt32().NotNullable()
            .WithColumn("Type").AsInt16().NotNullable()
            .WithColumn("CreationDate").AsDateTime().NotNullable()
            .WithColumn("Code").AsString(30).NotNullable();

    }

    public override void Down()
    {
        Delete.Table("Medications");
    }
}