using FluentMigrator;

namespace Solution.Host.Infrastructure.Store.Migrations;

[Migration(202412182143)]
public class AddUserStoreProcedures : Migration
{
    public override void Up()
    {
        Execute.Sql("""
            CREATE PROCEDURE CreateUser
                @Id UNIQUEIDENTIFIER,
                @FirstName NVARCHAR(100),
                @Surname NVARCHAR(100),
                @Patronymic NVARCHAR(100),
                @Email NVARCHAR(255),
                @PasswordHash NVARCHAR(255),
                @Address NVARCHAR(500),
                @PhoneNumber NVARCHAR(20)
            AS
            BEGIN
                INSERT INTO Users (Id, FirstName, Surname, Patronymic, Email, PasswordHash, Address, PhoneNumber)
                VALUES (@Id, @FirstName, @Surname, @Patronymic, @Email, @PasswordHash, @Address, @PhoneNumber);
            END;
        """);

        Execute.Sql("""
            CREATE PROCEDURE GetUserByEmail
                @Email NVARCHAR(100)
            AS
            BEGIN
                SELECT * FROM Users WHERE Email = @Email;
            END;
        """);
    }

    public override void Down()
    {
        Execute.Sql("DROP PROCEDURE IF EXISTS CreateUser;");
        Execute.Sql("DROP PROCEDURE IF EXISTS GetUserByEmail;");
    }
}