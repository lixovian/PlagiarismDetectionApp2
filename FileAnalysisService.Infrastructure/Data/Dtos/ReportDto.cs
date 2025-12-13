namespace FileAnalysisService.Infrastructure.Data.Dtos;

public sealed record ReportDto(
    Guid Id,
    Guid SubmissionId,
    bool? IsPlagiarism,
    string? WordCloudUrl
);