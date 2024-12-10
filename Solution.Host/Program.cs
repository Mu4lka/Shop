using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Scalar.AspNetCore;
using Solution.Host.Endpoints;
using Solution.Host.Infrastructure;
using Solution.Host.Infrastructure.Store.Migrations;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi(options =>
{
    options.AddDocumentTransformer<BearerSecuritySchemeTransformer>();
});

builder.Services.StartMigrator(builder.Configuration);
builder.Services.ConfigureInfrastructure();

builder.Services.AddHttpContextAccessor();
builder.Services.AddAuthorization();
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, opts =>
    {
        opts.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = false,
            ValidateAudience = false,
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration.GetValue<string>("SecretKey")!)),
        };
    });

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference(options =>
    {
        options.WithPreferredScheme(JwtBearerDefaults.AuthenticationScheme)
           .WithHttpBearerAuthentication(bearer =>
           {
               bearer.Token = "your-bearer-token";
           });
    });
}
app.UseAuthentication();
app.UseAuthorization();

UsersEndpoints.Map(app);
OrderEndpoints.Map(app);
ProductEndponts.Map(app);

app.Run();
