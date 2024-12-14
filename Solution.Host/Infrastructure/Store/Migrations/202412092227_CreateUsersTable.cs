using FluentMigrator;

namespace Solution.Host.Infrastructure.Store.Migrations;

[Migration(202412092227)]
public class CreateUsersTable : Migration
{
    public override void Up()
    {
        Create.Table("Users")
            .WithColumn("Id").AsGuid().PrimaryKey().WithDefault(SystemMethods.NewGuid)
            .WithColumn("Email").AsString(255).NotNullable().Unique()
            .WithColumn("PasswordHash").AsString(255).NotNullable()
            .WithColumn("FirstName").AsString(100).NotNullable()
            .WithColumn("Surname").AsString(100).NotNullable()
            .WithColumn("Patronymic").AsString(100).Nullable()
            .WithColumn("Address").AsString(500).NotNullable()
            .WithColumn("PhoneNumber").AsString(20).NotNullable();
    }

    public override void Down()
    {
        Delete.Table("Users");
    }
}
