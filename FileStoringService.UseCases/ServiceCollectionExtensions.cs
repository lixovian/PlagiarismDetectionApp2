using FileStoringService.UseCases.Complex.SubmitFile;
using FileStoringService.UseCases.Files.AddFile;
using FileStoringService.UseCases.Files.GetFileById;
using FileStoringService.UseCases.Files.ListFiles;
using FileStoringService.UseCases.Submissions.AddSubmission;
using FileStoringService.UseCases.Submissions.GetAssignmentSubmissions;
using FileStoringService.UseCases.Submissions.GetSubmissionById;
using FileStoringService.UseCases.Submissions.ListSubmissions;
using Microsoft.Extensions.DependencyInjection;

namespace FileStoringService.UseCases;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddUseCases(this IServiceCollection services)
    {
        services.AddScoped<ISubmitFileRequestHandler, SubmitFileRequestHandler>();
        
        // files
        services.AddScoped<IAddFileRequestHandler, AddFileRequestHandler>();
        services.AddScoped<IListFilesRequestHandler, ListFilesRequestHandler>();
        services.AddScoped<IGetFileByIdRequestHandler, GetFileByIdRequestHandler>();
        
        // submissions
        services.AddScoped<IAddSubmissionRequestHandler, AddSubmissionRequestHandler>();
        services.AddScoped<IGetSubmissionByIdRequestHandler, GetSubmissionByIdRequestHandler>();
        services.AddScoped<IListSubmissionsRequestHandler, ListSubmissionsRequestHandler>();
        services.AddScoped<IGetAssignmentSubmissionsRequestHandler, GetAssignmentSubmissionsRequestHandler>();

        return services;
    }
}