using FileStoringService.UseCases.Files.AddFile;
using FileStoringService.UseCases.Files.ListFiles;
using FileStoringService.UseCases.Submissions.AddSubmission;
using FileStoringService.UseCases.Submissions.ListSubmissions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;

namespace FileStoringService.Presentation.Endpoints;

public static class FileStoringEndpoints
{
    public static WebApplication MapFileStoringEndpoints(this WebApplication app)
    {
        MapFilesEndpoints(app);
        MapSubmissionsEndpoints(app);

        return app;
    }

    private static void MapFilesEndpoints(WebApplication app)
    {
        app.MapGet("/files", (IListFilesRequestHandler handler) =>
        {
            var response = handler.Handle();
            return Results.Ok(response);
        })
        .WithTags("Files")
        .WithName("GetFiles")
        .WithSummary("Get all files")
        .WithDescription("Get all stored files metadata from the database");

        app.MapPost("/files", (AddFileRequest request, IAddFileRequestHandler handler) =>
        {
            var response = handler.Handle(request);
            return Results.Ok(response);
        })
        .WithTags("Files")
        .WithName("AddFile")
        .WithSummary("Add a new file")
        .WithDescription("Add a new file metadata record to the database");
    }

    private static void MapSubmissionsEndpoints(WebApplication app)
    {
        app.MapGet("/submissions", (IListSubmissionsRequestHandler handler) =>
        {
            var response = handler.Handle();
            return Results.Ok(response);
        })
        .WithTags("Submissions")
        .WithName("GetSubmissions")
        .WithSummary("Get all submissions")
        .WithDescription("Get all submissions from the database");

        app.MapPost("/submissions", (AddSubmissionRequest request, IAddSubmissionRequestHandler handler) =>
        {
            var response = handler.Handle(request);
            return Results.Ok(response);
        })
        .WithTags("Submissions")
        .WithName("AddSubmission")
        .WithSummary("Add a new submission")
        .WithDescription("Add a new submission to the database");
    }
}
