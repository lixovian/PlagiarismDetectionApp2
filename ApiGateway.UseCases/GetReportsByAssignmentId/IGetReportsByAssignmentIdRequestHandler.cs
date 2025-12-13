using ApiGateway.Entities.Models.Reports;

namespace ApiGateway.UseCases.Reports.GetReportsByAssignmentId;

public interface IGetReportsByAssignmentIdRequestHandler
{
    IReadOnlyList<ReportDto> Handle(GetReportsByAssignmentIdRequest request);
}