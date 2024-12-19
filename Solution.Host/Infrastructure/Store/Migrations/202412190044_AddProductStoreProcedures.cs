using FluentMigrator;

namespace Solution.Host.Infrastructure.Store.Migrations;

[Migration(202412190044)]
public class AddProductStoreProcedures : Migration
{
    public override void Up()
    {
        Execute.Sql("""
            CREATE PROCEDURE GetAllProducts
            AS
            BEGIN
                SELECT * FROM products;
            END;
        """);

        Execute.Sql("""
            CREATE PROCEDURE GetProductsByIds
                @Ids NVARCHAR(MAX)
            AS
            BEGIN
                SELECT * 
                FROM products 
                WHERE id IN (SELECT value FROM STRING_SPLIT(@Ids, ','));
            END;
        """);
    }

    public override void Down()
    {
        Execute.Sql("DROP PROCEDURE IF EXISTS GetAllProducts;");
        Execute.Sql("DROP PROCEDURE IF EXISTS GetProductsByIds;");
    }
}
