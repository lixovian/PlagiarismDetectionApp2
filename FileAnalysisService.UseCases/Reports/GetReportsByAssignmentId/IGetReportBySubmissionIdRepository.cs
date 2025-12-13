using FileAnalysisService.Entities.Models;

namespace FileAnalysisService.UseCases.Reports.GetReportsByAssignmentId;

public interface IGetReportBySubmissionIdRepository
{
    Report? GetBySubmissionId(Guid submissionId);
}