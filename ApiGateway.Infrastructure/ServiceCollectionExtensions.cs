using ApiGateway.Infrastructure.Http;
using ApiGateway.UseCases.Reports;
using ApiGateway.UseCases.SubmitFile;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ApiGateway.Infrastructure;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services.AddHttpClient<IFileStoringClient, FileStoringClient>((serviceProvider, client) =>
        {
            var configuration = serviceProvider.GetRequiredService<IConfiguration>();
            
            var baseUrl = configuration["FileStoringApi:BaseUrl"];
            if (string.IsNullOrWhiteSpace(baseUrl))
                throw new InvalidOperationException("FileStoringApi:BaseUrl is not configured.");

            client.BaseAddress = new Uri(baseUrl);
        });

        services.AddHttpClient<IFileAnalysisClient, FileAnalysisClient>((serviceProvider, client) =>
        {
            var configuration = serviceProvider.GetRequiredService<IConfiguration>();
            
            var baseUrl = configuration["FileAnalysisApi:BaseUrl"];
            if (string.IsNullOrWhiteSpace(baseUrl))
                throw new InvalidOperationException("FileAnalysisApi:BaseUrl is not configured.");

            client.BaseAddress = new Uri(baseUrl);
        });

        return services;
    }
}