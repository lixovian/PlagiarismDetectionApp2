using FileStoringService.Infrastructure;
using FileStoringService.Presentation.Endpoints;
using FileStoringService.UseCases;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton(TimeProvider.System);

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
    {
        policy.WithOrigins("http://localhost:5002")
            .AllowAnyHeader()
            .AllowAnyMethod();
    });
});


builder.Services.AddOpenApi("api");

builder.Services.AddInfrastructure();

builder.Services.AddUseCases();

var app = builder.Build();

app.MapOpenApi();

app.MapFileStoringEndpoints();

app.Run();