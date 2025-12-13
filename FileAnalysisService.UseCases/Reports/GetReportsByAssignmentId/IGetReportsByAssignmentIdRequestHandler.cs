using FileAnalysisService.UseCases.Reports.CreateReport;

namespace FileAnalysisService.UseCases.Reports.GetReportsByAssignmentId;

public interface IGetReportsByAssignmentIdRequestHandler
{
    IReadOnlyList<CreateReportResponse> Handle(GetReportsByAssignmentIdRequest request);
}