namespace ApiGateway.Entities.Models.Reports;

public sealed record ReportDto(
    Guid Id,
    Guid SubmissionId,
    bool? IsPlagiarism,
    string? WordCloudUrl
);