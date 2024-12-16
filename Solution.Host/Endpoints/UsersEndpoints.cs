using Microsoft.AspNetCore.Mvc;
using Solution.Host.Contracts;
using Solution.Host.Domain.Entities;
using Solution.Host.Domain.Interfaces.Repositories;
using Solution.Host.Domain.ValueObjects;
using Solution.Host.Endpoints.Services;
using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace Solution.Host.Endpoints;

public static class UsersEndpoints
{
    public static void Map(this IEndpointRouteBuilder builder)
    {
        var group = builder.MapGroup("")
            .WithTags("Пользователи");

        group.MapPost("api/v1/users/register", RegisterAsync)
            .WithSummary("Зарегистрировать пользователя")
            .Produces(StatusCodes.Status201Created);

        group.MapPost("api/v1/users/login", LoginAsync)
            .WithSummary("Авторизовать пользователя")
            .Produces(StatusCodes.Status200OK);
    }

    private static async Task<IResult> LoginAsync(
        [FromBody] UserLoginRequest request,
        [FromServices] IUsersRepository usersRepository,
        [FromServices] IPasswordHasher passwordHasher,
        [FromServices] IJwtGenerator jwtGenerator)
    {
        var user = await usersRepository.GetByEmailAsync(request.Email);

        if (user == null)
            return Results.BadRequest("Неверный email или пароль");

        var isValid = passwordHasher.Verify(request.Password, user.PasswordHash);

        if (!isValid)
            return Results.BadRequest("Неверный email или пароль");

        string jwtToken = jwtGenerator.GenerateToken(user);
        return Results.Ok(jwtToken);
    }

    private static async Task<IResult> RegisterAsync(
        [FromServices] IUsersRepository usersRepository,
        [FromServices] IPasswordHasher passwordHasher,
        [FromBody] UserRegisterRequest request)
    {
        var user = await usersRepository.GetByEmailAsync(request.Email);

        if (user != null)
            return Results.Conflict("Пользователь с таким Email уже существует");

        string hashPassword = passwordHasher.Hash(request.Password);

        var newUser = new User(
            Guid.NewGuid(),
            request.Email,
            hashPassword,
            new FullName(request.FirstName, request.Surname, request.Patronymic),
            request.Address,
            request.PhoneNumber);

        await usersRepository.CreateAsync(newUser);
        return Results.Created();
    }
}
