using ApiGateway.Entities.Models.Reports;

namespace ApiGateway.UseCases.Reports.CreateReport;

internal sealed class CreateReportRequestHandler(
    IFileAnalysisClient fileAnalysisClient)
    : ICreateReportRequestHandler
{
    public CreateReportResponse Handle(CreateReportRequest request)
    {
        return fileAnalysisClient.CreateReport(request.ToDto());
    }
}