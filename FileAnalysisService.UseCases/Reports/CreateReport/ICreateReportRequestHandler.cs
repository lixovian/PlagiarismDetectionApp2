namespace FileAnalysisService.UseCases.Reports.CreateReport;

public interface ICreateReportRequestHandler
{
    CreateReportResponse Handle(CreateReportRequest request);
}