using FileAnalysisService.UseCases.Reports.CreateReport;
using FileAnalysisService.UseCases.Reports.GetReportsByAssignmentId;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace FileAnalysisService.Presentation.Endpoints;

public static class FileAnalysisEndpoints
{
    public static WebApplication MapFileAnalysisEndpoints(this WebApplication app)
    {
        app.MapGroup("/reports")
            .WithTags("Reports")
            .MapCreateReport()
            .MapGetReportsByAssignmentId();

        return app;
    }

    private static RouteGroupBuilder MapCreateReport(this RouteGroupBuilder group)
    {
        group.MapPost("", (CreateReportRequest request, ICreateReportRequestHandler handler) =>
            {
                var response = handler.Handle(request);
                return Results.Ok(response);
            })
            .WithName("CreateReport")
            .WithSummary("Create a report for a submission")
            .WithDescription("Creates a plagiarism report for the given submission ID")
            .WithOpenApi();

        return group;
    }

    private static RouteGroupBuilder MapGetReportsByAssignmentId(this RouteGroupBuilder group)
    {
        group.MapGet("assignment/{assignmentId:int}",
                (int assignmentId, IGetReportsByAssignmentIdRequestHandler handler) =>
                {
                    var response = handler.Handle(new GetReportsByAssignmentIdRequest(assignmentId));
                    return Results.Ok(response);
                })
            .WithName("GetReportsByAssignmentId")
            .WithSummary("Get reports by assignment ID")
            .WithDescription("Returns reports for all submissions of the assignment. Missing reports are created automatically.")
            .WithOpenApi();

        return group;
    }
}