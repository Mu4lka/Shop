using FluentMigrator;

namespace Solution.Host.Infrastructure.Store.Migrations;

[Migration(202412102026)]
public class CreateOrderItemTable : Migration
{
    public override void Up()
    {
        Create.Table("OrderItems")
            .WithColumn("Id").AsGuid().PrimaryKey().WithDefault(SystemMethods.NewGuid)
            .WithColumn("OrderId").AsGuid().NotNullable()
            .WithColumn("ProductId").AsGuid().NotNullable()
            .WithColumn("Count").AsInt64().NotNullable()
            .WithColumn("Amount").AsDecimal().NotNullable()
            .WithColumn("Currency").AsString(10).NotNullable();

        Create.ForeignKey("FK_OrderItem_Order")
            .FromTable("OrderItems").ForeignColumn("OrderId")
            .ToTable("Orders").PrimaryColumn("Id");

        Create.ForeignKey("FK_OrdersItem_Product")
            .FromTable("OrderItems").ForeignColumn("ProductId")
            .ToTable("Products").PrimaryColumn("Id");
    }

    public override void Down()
    {
        Delete.ForeignKey("FK_OrderItem_Order").OnTable("OrderItems");
        Delete.ForeignKey("FK_OrdersItem_Product").OnTable("OrderItems");

        Delete.Table("OrderItems");
    }
}
