using FileStoringService.Infrastructure;
using FileStoringService.Presentation.Endpoints;
using FileStoringService.UseCases;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton(TimeProvider.System);

builder.Services.AddOpenApi("api");

builder.Services.AddInfrastructure();
builder.Services.AddUseCases();

var app = builder.Build();

app.MapOpenApi();
app.UseSwaggerUI(options =>
{
    options.SwaggerEndpoint("/openapi/api.json", "File Storing API");
});

app.MapFileStoringEndpoints();

app.Run();