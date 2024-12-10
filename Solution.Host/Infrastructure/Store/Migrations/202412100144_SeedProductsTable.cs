using FluentMigrator;

namespace Solution.Host.Infrastructure.Store.Migrations;

[Migration(202412100144)]
public class SeedProductsTable : Migration
{
    public override void Up()
    {
        Insert.IntoTable("Products").Row(new
        {
            Title = "Laptop Acer Predator Helios 300",
            Description = "Высокопроизводительный игровой ноутбук с экраном 15.6 дюймов и процессором Intel i7.",
            AvailableQuantity = 50,
            Sku = "LAP001",
            Amount = 1299.99m,
            Currency = "USD"
        });

        Insert.IntoTable("Products").Row(new
        {
            Title = "Smartphone Apple iPhone 14 Pro",
            Description = "Смартфон с экраном 6.1 дюймов, процессором A16 Bionic и улучшенной камерой.",
            AvailableQuantity = 150,
            Sku = "IPH001",
            Amount = 1099.99m,
            Currency = "USD"
        });

        Insert.IntoTable("Products").Row(new
        {
            Title = "Gaming Chair DXRacer Racing Series",
            Description = "Игровое кресло с поддержкой спины, регулируемой высотой и подлокотниками.",
            AvailableQuantity = 200,
            Sku = "CHAIR001",
            Amount = 299.99m,
            Currency = "USD"
        });

        Insert.IntoTable("Products").Row(new
        {
            Title = "Wireless Mouse Logitech G Pro X",
            Description = "Игровая мышь с беспроводным соединением и высокоточным сенсором HERO.",
            AvailableQuantity = 120,
            Sku = "MOUSE001",
            Amount = 89.99m,
            Currency = "USD"
        });

        Insert.IntoTable("Products").Row(new
        {
            Title = "4K TV Samsung QLED",
            Description = "Телевизор с экраном 55 дюймов, поддержка 4K и HDR.",
            AvailableQuantity = 30,
            Sku = "TV001",
            Amount = 799.99m,
            Currency = "USD"
        });

        Insert.IntoTable("Products").Row(new
        {
            Title = "Smartwatch Garmin Fenix 7",
            Description = "Многофункциональные спортивные часы с GPS, мониторингом здоровья и длительным временем работы.",
            AvailableQuantity = 75,
            Sku = "WATCH001",
            Amount = 499.99m,
            Currency = "USD"
        });

        Insert.IntoTable("Products").Row(new
        {
            Title = "Bluetooth Headphones Sony WH-1000XM5",
            Description = "Наушники с активным шумоподавлением и до 30 часов работы.",
            AvailableQuantity = 50,
            Sku = "HEADPHONE001",
            Amount = 349.99m,
            Currency = "USD"
        });

        Insert.IntoTable("Products").Row(new
        {
            Title = "Electric Kettle Philips HD9350/90",
            Description = "Электрический чайник с мощностью 2200 Вт и функцией автоотключения.",
            AvailableQuantity = 200,
            Sku = "KETTLE001",
            Amount = 39.99m,
            Currency = "USD"
        });

        Insert.IntoTable("Products").Row(new
        {
            Title = "Cordless Vacuum Cleaner Dyson V15 Detect",
            Description = "Беспроводной пылесос с мощностью всасывания 230 AW и датчиком для обнаружения микроскопических частиц.",
            AvailableQuantity = 40,
            Sku = "VACUUM001",
            Amount = 799.99m,
            Currency = "USD"
        });

        Insert.IntoTable("Products").Row(new
        {
            Title = "Digital Camera Canon EOS 90D",
            Description = "Цифровая зеркальная камера с разрешением 32.5 МП и 4K видео.",
            AvailableQuantity = 25,
            Sku = "CAMERA001",
            Amount = 1299.99m,
            Currency = "USD"
        });

        Insert.IntoTable("Products").Row(new
        {
            Title = "Air Purifier Xiaomi Mi Air Purifier 3H",
            Description = "Очиститель воздуха с 3-х ступенчатой системой фильтрации и Wi-Fi управлением.",
            AvailableQuantity = 100,
            Sku = "AIRPURIFIER001",
            Amount = 149.99m,
            Currency = "USD"
        });

        Insert.IntoTable("Products").Row(new
        {
            Title = "Robot Vacuum Cleaner iRobot Roomba 980",
            Description = "Робот-пылесос с функцией очищения и распознавания препятствий.",
            AvailableQuantity = 60,
            Sku = "ROBOTVAC001",
            Amount = 499.99m,
            Currency = "USD"
        });

        Insert.IntoTable("Products").Row(new
        {
            Title = "Electric Scooter Xiaomi Mi Electric Scooter 3",
            Description = "Электрический скутер с максимальной скоростью 25 км/ч и дальностью до 30 км.",
            AvailableQuantity = 120,
            Sku = "SCOOTER001",
            Amount = 399.99m,
            Currency = "USD"
        });

        Insert.IntoTable("Products").Row(new
        {
            Title = "Tablet Samsung Galaxy Tab S7",
            Description = "Планшет с экраном 11 дюймов и процессором Snapdragon 865+.",
            AvailableQuantity = 80,
            Sku = "TABLET001",
            Amount = 649.99m,
            Currency = "USD"
        });

        Insert.IntoTable("Products").Row(new
        {
            Title = "Blender Vitamix 5200",
            Description = "Блендер с мощностью 2 л. и функцией приготовления горячих супов.",
            AvailableQuantity = 40,
            Sku = "BLENDER001",
            Amount = 449.99m,
            Currency = "USD"
        });

        Insert.IntoTable("Products").Row(new
        {
            Title = "Stand Mixer KitchenAid Artisan",
            Description = "Миксер с 10 скоростями и возможностью использования множества насадок.",
            AvailableQuantity = 50,
            Sku = "MIXER001",
            Amount = 379.99m,
            Currency = "USD"
        });

        Insert.IntoTable("Products").Row(new
        {
            Title = "Nespresso Coffee Machine Lattissima One",
            Description = "Кофемашина с функцией приготовления капучино и эспрессо.",
            AvailableQuantity = 150,
            Sku = "COFFEE001",
            Amount = 249.99m,
            Currency = "USD"
        });

        Insert.IntoTable("Products").Row(new
        {
            Title = "Gaming Laptop MSI GE76 Raider",
            Description = "Игровой ноутбук с экраном 17.3 дюйма, процессором Intel i9 и графикой NVIDIA RTX 3080.",
            AvailableQuantity = 25,
            Sku = "GAMINGLAP001",
            Amount = 2399.99m,
            Currency = "USD"
        });

        Insert.IntoTable("Products").Row(new
        {
            Title = "4K Projector BenQ TK850i",
            Description = "Проектор 4K с поддержкой HDR и умными функциями для дома.",
            AvailableQuantity = 10,
            Sku = "PROJECTOR001",
            Amount = 1799.99m,
            Currency = "USD"
        });
    }

    public override void Down()
    {
        Delete.FromTable("Products").AllRows();
    }
}
