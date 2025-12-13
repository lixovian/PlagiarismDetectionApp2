using ApiGateway.UseCases.SubmitFile;
using ApiGateway.UseCases.Reports;
using ApiGateway.UseCases.Reports.CreateReport;
using ApiGateway.UseCases.Reports.GetReportsByAssignmentId;
using Microsoft.Extensions.DependencyInjection;

namespace ApiGateway.UseCases;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddUseCases(this IServiceCollection services)
    {
        services.AddScoped<ISubmitFileRequestHandler, SubmitFileRequestHandler>();
        services.AddScoped<ICreateReportRequestHandler, CreateReportRequestHandler>();
        services.AddScoped<IGetReportsByAssignmentIdRequestHandler, GetReportsByAssignmentIdRequestHandler>();

        return services;
    }
}