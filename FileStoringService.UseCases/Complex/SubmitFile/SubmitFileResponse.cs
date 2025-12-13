namespace FileStoringService.UseCases.Submissions.SubmitFile;

public sealed record SubmitFileResponse(
    Guid SubmissionId,
    Guid StoredFileId,
    string Sha256,
    long Size,
    DateTime SubmittedAt
);