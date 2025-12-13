using ApiGateway.Infrastructure;
using ApiGateway.Presentation.Endpoints;
using ApiGateway.UseCases;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton(TimeProvider.System);

builder.Services.AddOpenApi("api");

builder.Services.AddInfrastructure();
builder.Services.AddUseCases();

var app = builder.Build();

app.MapOpenApi();
app.UseSwaggerUI(options =>
{
    options.SwaggerEndpoint("/openapi/api.json", "API Gateway");

    var fileStoringSwagger = builder.Configuration["Swagger:FileStoring"];
    if (!string.IsNullOrWhiteSpace(fileStoringSwagger))
    {
        options.SwaggerEndpoint(fileStoringSwagger, "File Storing API");
    }

    var fileAnalysisSwagger = builder.Configuration["Swagger:FileAnalysis"];
    if (!string.IsNullOrWhiteSpace(fileAnalysisSwagger))
    {
        options.SwaggerEndpoint(fileAnalysisSwagger, "File Analysis API");
    }
});

app.MapApiGatewayEndpoints();

app.Run();