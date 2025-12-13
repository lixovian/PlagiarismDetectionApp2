using FileAnalysisService.Infrastructure;
using FileAnalysisService.Presentation.Endpoints;
using FileAnalysisService.UseCases;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton(TimeProvider.System);

builder.Services.AddOpenApi("api");

builder.Services.AddInfrastructure();
builder.Services.AddUseCases();

var app = builder.Build();

app.MapOpenApi();
app.UseSwaggerUI(options =>
{
    options.SwaggerEndpoint("/openapi/api.json", "File Analysis API");
});

app.MapFileAnalysisEndpoints();

app.Run();