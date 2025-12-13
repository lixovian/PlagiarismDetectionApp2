using ApiGateway.Entities.Models.Reports;

namespace ApiGateway.UseCases.Reports.GetReportsByAssignmentId;

internal sealed class GetReportsByAssignmentIdRequestHandler(
    IFileAnalysisClient fileAnalysisClient)
    : IGetReportsByAssignmentIdRequestHandler
{
    public IReadOnlyList<ReportDto> Handle(GetReportsByAssignmentIdRequest request)
    {
        return fileAnalysisClient.GetReportsByAssignmentId(request.AssignmentId);
    }
}