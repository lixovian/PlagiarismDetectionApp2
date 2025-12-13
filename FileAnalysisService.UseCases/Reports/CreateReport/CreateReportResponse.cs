namespace FileAnalysisService.UseCases.Reports.CreateReport;

public sealed record CreateReportResponse(
    Guid Id,
    Guid SubmissionId,
    bool? IsPlagiarism,
    string? WordCloudUrl
);