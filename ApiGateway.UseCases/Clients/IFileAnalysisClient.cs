using ApiGateway.Entities.Models.Reports;

namespace ApiGateway.UseCases.Reports;

public interface IFileAnalysisClient
{
    CreateReportResponse CreateReport(CreateReportRequest request);
    IReadOnlyList<ReportDto> GetReportsByAssignmentId(int assignmentId);
}