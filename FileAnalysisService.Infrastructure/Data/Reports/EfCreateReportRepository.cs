using FileAnalysisService.Entities.Models;
using FileAnalysisService.Infrastructure.Data.Dtos;
using FileAnalysisService.UseCases.Reports.CreateReport;

namespace FileAnalysisService.Infrastructure.Data.Reports;

internal sealed class EfCreateReportRepository(FileAnalysisDbContext dbContext) : ICreateReportRepository
{
    public void Add(Report report)
    {
        dbContext.Reports.Add(report.ToDto());
        dbContext.SaveChanges();
    }
}