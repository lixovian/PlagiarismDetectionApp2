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
});

app.MapApiGatewayEndpoints();

app.Run();