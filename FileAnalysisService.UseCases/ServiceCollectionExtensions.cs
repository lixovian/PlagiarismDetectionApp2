using FileAnalysisService.UseCases.Reports.CreateReport;
using FileAnalysisService.UseCases.Reports.GetReportsByAssignmentId;
using Microsoft.Extensions.DependencyInjection;

namespace FileAnalysisService.UseCases;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddUseCases(this IServiceCollection services)
    {
        services.AddScoped<ICreateReportRequestHandler, CreateReportRequestHandler>();
        services.AddScoped<IGetReportsByAssignmentIdRequestHandler, GetReportsByAssignmentIdRequestHandler>();
        
        return services;
    }
}