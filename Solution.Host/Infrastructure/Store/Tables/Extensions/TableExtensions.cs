using Solution.Host.Domain.Entities;
using Solution.Host.Domain.ValueObjects;

namespace Solution.Host.Infrastructure.Store.Tables.Extensions;

internal static class TableExtensions
{
    public static Product ToProduct(this ProductTable source)
        => Product.Init(
            source.Id,
            source.Title,
            source.Description,
            source.AvailableQuantity,
            Sku.Create(source.Sku),
            new Price(source.Amount, source.Currency));

    public static UserTable ToTable(this User source)
        => new UserTable()
        {
            Id = source.Id,
            FirstName = source.FullName.FirstName,
            Surname = source.FullName.Surname,
            Patronymic = source.FullName.Patronymic,
            Email = source.Email,
            PasswordHash = source.PasswordHash,
            Address = source.Address,
            PhoneNumber = source.PhoneNumber,
        };

    public static User ToUser(this UserTable source)
        => new User(
            source.Id,
            source.Email,
            source.PasswordHash,
            new FullName(source.FirstName, source.Surname, source.Patronymic),
            source.Address,
            source.PhoneNumber
            );
}
