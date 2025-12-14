using FileAnalysisService.Infrastructure.Data;
using FileAnalysisService.Infrastructure.Data.Reports;
using FileAnalysisService.Infrastructure.WordCloud;
using FileAnalysisService.UseCases.Reports.CreateReport;
using FileAnalysisService.UseCases.Reports.GetReportsByAssignmentId;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FileAnalysisService.Infrastructure;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services.AddDbContext<FileAnalysisDbContext>((serviceProvider, options) =>
        {
            var configuration = serviceProvider.GetRequiredService<IConfiguration>();
            
            var cs = configuration.GetConnectionString("Db");
            options.UseNpgsql(cs);
        });
        
        services.AddHostedService<MigrationRunner>();
        
        services.AddScoped<ICreateReportRepository, EfCreateReportRepository>();
        services.AddScoped<IGetReportBySubmissionIdRepository, EfGetReportBySubmissionIdRepository>();
        
        services.AddScoped<IWordCloudGenerator, QuickChartWordCloudGenerator>();

        services.AddHttpClient<IFileStoringClient, FileStoringClient>((serviceProvider, client) =>
        {
            var configuration = serviceProvider.GetRequiredService<IConfiguration>();
            
            var baseUrl = configuration["FileStoringApi:BaseUrl"];
            if (string.IsNullOrWhiteSpace(baseUrl))
                throw new InvalidOperationException("FileStoringApi:BaseUrl is not configured.");

            client.BaseAddress = new Uri(baseUrl);
        });

        return services;
    }
}