using FileAnalysisService.Entities.Models;
using FileAnalysisService.UseCases.Reports.GetReportsByAssignmentId;

namespace FileAnalysisService.Infrastructure.Data.Reports;

internal sealed class EfGetReportBySubmissionIdRepository(FileAnalysisDbContext dbContext)
    : IGetReportBySubmissionIdRepository
{
    public Report? GetBySubmissionId(Guid submissionId)
    {
        return dbContext.Reports
            .SingleOrDefault(r => r.SubmissionId == submissionId)
            ?.ToEntity();
    }
}