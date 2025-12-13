using ApiGateway.UseCases.SubmitFile;
using ApiGateway.UseCases.Reports.CreateReport;
using ApiGateway.UseCases.Reports.GetReportsByAssignmentId;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace ApiGateway.Presentation.Endpoints;

public static class ApiGatewayEndpoints
{
    public static WebApplication MapApiGatewayEndpoints(this WebApplication app)
    {
        app.MapGroup("")
            .WithTags("Gateway")
            .MapSubmitFile();

        app.MapGroup("/reports")
            .WithTags("Reports")
            .MapCreateReport()
            .MapGetReportsByAssignmentId();

        return app;
    }

    private static RouteGroupBuilder MapSubmitFile(this RouteGroupBuilder group)
    {
        group.MapPost("/submit-file", (SubmitFileRequest request, ISubmitFileRequestHandler handler) =>
            {
                var response = handler.Handle(request);
                return Results.Ok(response);
            })
            .WithName("SubmitFile")
            .WithSummary("Submit a file (gateway)")
            .WithDescription("Gateway endpoint that submits a file to FileStoringService (complex submit-file).")
            .WithOpenApi();

        return group;
    }

    private static RouteGroupBuilder MapCreateReport(this RouteGroupBuilder group)
    {
        group.MapPost("", (CreateReportRequest request, ICreateReportRequestHandler handler) =>
            {
                var response = handler.Handle(request);
                return Results.Ok(response);
            })
            .WithName("CreateReport")
            .WithSummary("Create a report (gateway)")
            .WithDescription("Gateway endpoint that creates a plagiarism report via FileAnalysisService.")
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
            .WithSummary("Get reports by assignment ID (gateway)")
            .WithDescription("Gateway endpoint that returns reports for all submissions of the assignment via FileAnalysisService.")
            .WithOpenApi();

        return group;
    }
}
