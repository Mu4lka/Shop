using FluentMigrator;

namespace Solution.Host.Infrastructure.Store.Migrations;

[Migration(202412190205)]
public class AddOrderStoreProcedures : Migration
{
    public override void Up()
    {
        Execute.Sql("""
            CREATE PROCEDURE CreateOrderItem
                @Id UNIQUEIDENTIFIER,
                @OrderId UNIQUEIDENTIFIER,
                @ProductId UNIQUEIDENTIFIER,
                @Count BIGINT,
                @Amount DECIMAL,
                @Currency NVARCHAR(10)
            AS
            BEGIN
                INSERT INTO OrderItems (Id, OrderId, ProductId, Count, Amount, Currency)
                VALUES (@Id, @OrderId, @ProductId, @Count, @Amount, @Currency)
            END;
            """);

        Execute.Sql("""
            CREATE PROCEDURE CreateOrder
                @Id UNIQUEIDENTIFIER,
                @CreatedAt DATETIME,
                @Status INT,
                @UserId UNIQUEIDENTIFIER
            AS
            BEGIN
                INSERT INTO Orders (Id, CreatedAt, Status, UserId)
                VALUES (@Id, @CreatedAt, @Status, @UserId)
            END;
            """);

        Execute.Sql("""
            CREATE PROCEDURE GetOrdersByUserId
                @Id UNIQUEIDENTIFIER
            AS
            BEGIN
                SELECT * FROM Orders o 
                JOIN OrderItems oi ON o.Id = oi.OrderId 
                JOIN Products p ON oi.ProductId = p.Id 
                WHERE o.UserId = @Id
            END;
            """);
    }

    public override void Down()
    {
        Execute.Sql("DROP PROCEDURE IF EXISTS CreateOrderItem");
        Execute.Sql("DROP PROCEDURE IF EXISTS CreateOrder");
        Execute.Sql("DROP PROCEDURE IF EXISTS GetOrdersByUserId");
    }
}
