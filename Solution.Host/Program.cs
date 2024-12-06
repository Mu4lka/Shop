using Scalar.AspNetCore;
using Solution.Host.Endpoints;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();

var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference();
}
UserEndpoints.Map(app);
OrderEndpoints.Map(app);
ProductEndponts.Map(app);
app.Run();