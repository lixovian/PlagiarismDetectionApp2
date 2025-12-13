using FileStoringService.Infrastructure.Data;
using FileStoringService.Infrastructure.Data.Files;
using FileStoringService.Infrastructure.Data.Submissions;
using FileStoringService.UseCases.Files.AddFile;
using FileStoringService.UseCases.Files.GetFileById;
using FileStoringService.UseCases.Files.ListFiles;
using FileStoringService.UseCases.Submissions.AddSubmission;
using FileStoringService.UseCases.Submissions.ListSubmissions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FileStoringService.Infrastructure;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services.AddDbContext<FileStoringDbContext>((serviceProvider, options) =>
        {
            var configuration = serviceProvider.GetRequiredService<IConfiguration>();
            options.UseNpgsql(configuration.GetConnectionString("Default"));
        });

        // Files
        services.AddScoped<IAddFileRepository, EfAddFileRepository>();
        services.AddScoped<IListFilesRepository, EfListFilesRepository>();
        services.AddScoped<IGetFileByIdRepository, EfGetFileByIdRepository>();

        // Submissions
        services.AddScoped<IAddSubmissionRepository, EfAddSubmissionRepository>();
        services.AddScoped<IListSubmissionsRepository, EfListSubmissionsRepository>();

        return services;
    }
}