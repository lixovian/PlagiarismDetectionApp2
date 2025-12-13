using ApiGateway.Entities.Models.Reports;

namespace ApiGateway.UseCases.Reports.CreateReport;

public sealed record CreateReportRequest(Guid SubmissionId)
{
    public ApiGateway.Entities.Models.Reports.CreateReportRequest ToDto() =>
        new(SubmissionId);
}