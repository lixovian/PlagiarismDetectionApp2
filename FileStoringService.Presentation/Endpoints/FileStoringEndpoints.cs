using FileStoringService.UseCases.Files.AddFile;
using FileStoringService.UseCases.Files.GetFileById;
using FileStoringService.UseCases.Files.ListFiles;
using FileStoringService.UseCases.Submissions.AddSubmission;
using FileStoringService.UseCases.Submissions.GetAssignmentSubmissions;
using FileStoringService.UseCases.Submissions.ListSubmissions;
using FileStoringService.UseCases.Submissions.SubmitFile;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace FileStoringService.Presentation.Endpoints;

public static class FileStoringEndpoints
{
    public static WebApplication MapFileStoringEndpoints(this WebApplication app)
    {
        app.MapGroup("/files")
            .WithTags("Files")
            .MapGetFiles()
            .MapAddFile()
            .MapGetFileById();

        app.MapGroup("/submissions")
            .WithTags("Submissions")
            .MapGetSubmissions()
            .MapAddSubmission()
            .MapGetAssignmentSubmissions();
        
        app.MapGroup("/complex")
            .WithTags("Complex")
            .MapSubmitFile();


        return app;
    }

    private static RouteGroupBuilder MapGetFiles(this RouteGroupBuilder group)
    {
        group.MapGet("", (IListFilesRequestHandler handler) =>
            {
                var response = handler.Handle();
                return Results.Ok(response);
            })
            .WithName("GetFiles")
            .WithSummary("Get all files")
            .WithDescription("Get all stored files metadata from the database")
            .WithOpenApi();

        return group;
    }

    private static RouteGroupBuilder MapAddFile(this RouteGroupBuilder group)
    {
        group.MapPost("", (AddFileRequest request, IAddFileRequestHandler handler) =>
            {
                var response = handler.Handle(request);
                return Results.Ok(response);
            })
            .WithName("AddFile")
            .WithSummary("Add a new file")
            .WithDescription("Add a new file metadata record to the database")
            .WithOpenApi();

        return group;
    }

    private static RouteGroupBuilder MapGetFileById(this RouteGroupBuilder group)
    {
        group.MapGet("/{id}", (Guid id, IGetFileByIdRequestHandler handler) =>
            {
                var response = handler.Handle(new GetFileByIdRequest(id));
                return response is null ? Results.NotFound() : Results.Ok(response);
            })
            .WithName("GetFileById")
            .WithSummary("Get a file by ID")
            .WithDescription("Get a stored file metadata record by ID from the database")
            .WithOpenApi();

        return group;
    }

    private static RouteGroupBuilder MapGetSubmissions(this RouteGroupBuilder group)
    {
        group.MapGet("", (IListSubmissionsRequestHandler handler) =>
            {
                var response = handler.Handle();
                return Results.Ok(response);
            })
            .WithName("GetSubmissions")
            .WithSummary("Get all submissions")
            .WithDescription("Get all submissions from the database")
            .WithOpenApi();

        return group;
    }

    private static RouteGroupBuilder MapAddSubmission(this RouteGroupBuilder group)
    {
        group.MapPost("", (AddSubmissionRequest request, IAddSubmissionRequestHandler handler) =>
            {
                var response = handler.Handle(request);
                return Results.Ok(response);
            })
            .WithName("AddSubmission")
            .WithSummary("Add a new submission")
            .WithDescription("Add a new submission to the database")
            .WithOpenApi();

        return group;
    }
    
    private static RouteGroupBuilder MapGetAssignmentSubmissions(this RouteGroupBuilder group)
    {
        group.MapGet("assignment/{assignmentId:int}",
                (int assignmentId, IGetAssignmentSubmissionsRequestHandler handler) =>
                {
                    var response = handler.Handle(new GetAssignmentSubmissionsRequest(assignmentId));
                    return Results.Ok(response);
                })
            .WithName("GetAssignmentSubmissions")
            .WithSummary("Get submissions by assignment ID")
            .WithDescription("Get all submissions that belong to a specific assignment ID")
            .WithOpenApi();

        return group;
    }

    private static RouteGroupBuilder MapSubmitFile(this RouteGroupBuilder group)
    {
        group.MapPost("submit-file", (SubmitFileRequest request, ISubmitFileRequestHandler handler) =>
            {
                var response = handler.Handle(request);
                return Results.Ok(response);
            })
            .WithName("SubmitFile")
            .WithSummary("Submit a file for an assignment")
            .WithDescription("Creates a stored file (with computed size and sha256) and creates a submission linked to that file")
            .WithOpenApi();

        return group;
    }

}
