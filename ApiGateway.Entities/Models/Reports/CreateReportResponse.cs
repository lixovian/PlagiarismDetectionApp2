namespace ApiGateway.Entities.Models.Reports;

public sealed record CreateReportResponse(
    Guid Id,
    Guid SubmissionId,
    bool? IsPlagiarism,
    string? WordCloudUrl
);