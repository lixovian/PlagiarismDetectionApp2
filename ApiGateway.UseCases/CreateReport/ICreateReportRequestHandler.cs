using ApiGateway.Entities.Models.Reports;

namespace ApiGateway.UseCases.Reports.CreateReport;

public interface ICreateReportRequestHandler
{
    CreateReportResponse Handle(CreateReportRequest request);
}