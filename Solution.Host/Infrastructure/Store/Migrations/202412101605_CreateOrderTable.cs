using FluentMigrator;

namespace Solution.Host.Infrastructure.Store.Migrations;

[Migration(202412101605)]
public class CreateOrderTable : Migration
{
    public override void Up()
    {
        Create.Table("Orders")
            .WithColumn("Id").AsGuid().PrimaryKey().WithDefault(SystemMethods.NewGuid)
            .WithColumn("UserId").AsGuid().NotNullable()
            .WithColumn("CreatedAt").AsDateTime().NotNullable().WithDefault(SystemMethods.CurrentUTCDateTime)
            .WithColumn("Status").AsInt32().NotNullable();

        Create.ForeignKey("FK_Order_User")
            .FromTable("Orders").ForeignColumn("UserId")
            .ToTable("Users").PrimaryColumn("Id");
    }

    public override void Down()
    {
        Delete.ForeignKey("FK_Order_User").OnTable("Orders");

        Delete.Table("Orders");
    }
}
