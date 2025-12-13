using FileAnalysisService.Entities.Models;

namespace FileAnalysisService.UseCases.Reports.CreateReport;

public interface ICreateReportRepository
{
    void Add(Report report);
}