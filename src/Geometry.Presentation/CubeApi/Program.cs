using Geometry.Application.Interfaces.Repositories;
using Geometry.Application.Interfaces.Services;
using Geometry.Application.Services;

using Geometry.Infrastructure.Repositories;

using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add controllers
builder.Services.AddControllers();

// OpenAPI & Swagger
builder.Services.AddOpenApi();
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Geometry API",
        Version = "v1",
        Description = "A REST API for managing geometric entities."
    });
});

// ===============================================================
// 🔥 Assignment 8 Simplification
// Cube has been DISABLED because CubeRepository requires EF Core.
// Cylinder uses in-memory repository — works without database.
// ===============================================================

// -------------------- Cylinder Dependencies --------------------
builder.Services.AddSingleton<ICylinderRepository, CylinderRepository>();
builder.Services.AddScoped<ICylinderService, CylinderService>();

var app = builder.Build();

// Swagger enabled for development
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Geometry API v1");
        c.RoutePrefix = "swagger";
    });
}

// Map endpoints
app.MapControllers();

// Run the API
app.Run();
