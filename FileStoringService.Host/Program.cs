using FileStoringService.Infrastructure;
using FileStoringService.Presentation.Endpoints;
using FileStoringService.UseCases;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton(TimeProvider.System);

builder.Services.AddOpenApi("api");

builder.Services.AddInfrastructure();

builder.Services.AddUseCases();

var app = builder.Build();

app.MapOpenApi();
app.MapScalarApiReference(options =>
{
    options.Title = "File Storing API";
    options.OpenApiRoutePattern = "/openapi/{documentName}.json";
}); 

app.MapFileStoringEndpoints();

app.Run();