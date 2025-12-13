using FileAnalysisService.Infrastructure;
using FileAnalysisService.Presentation.Endpoints;
using FileAnalysisService.UseCases;

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

app.MapFileAnalysisEndpoints();

app.Run();