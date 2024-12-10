using FluentMigrator;

namespace Solution.Host.Infrastructure.Store.Migrations;

[Migration(202412100135)]
public class CreateProductsTable : Migration
{
    public override void Up()
    {
        Create.Table("Products")
            .WithColumn("Id").AsGuid().PrimaryKey().WithDefault(SystemMethods.NewGuid)
            .WithColumn("Title").AsString(200).NotNullable()
            .WithColumn("Description").AsString(int.MaxValue).NotNullable()
            .WithColumn("AvailableQuantity").AsInt32().NotNullable()
            .WithColumn("Sku").AsString(100).NotNullable().Unique()
            .WithColumn("Amount").AsDecimal().NotNullable()
            .WithColumn("Currency").AsString(10).NotNullable();
    }

    public override void Down()
    {
        Delete.Table("Products");
    }
}