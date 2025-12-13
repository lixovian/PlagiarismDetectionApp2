using FileAnalysisService.Infrastructure;
using FileAnalysisService.Presentation.Endpoints;
using FileAnalysisService.UseCases;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton(TimeProvider.System);

// OpenAPI
builder.Services.AddOpenApi("api");

// Infrastructure + UseCases
builder.Services.AddInfrastructure();
builder.Services.AddUseCases();

var app = builder.Build();

// OpenAPI + Swagger UI
app.MapOpenApi();
app.UseSwaggerUI(options =>
{
    options.SwaggerEndpoint("/openapi/api.json", "File Analysis API");
});

// Endpoints
app.MapFileAnalysisEndpoints();

app.Run();