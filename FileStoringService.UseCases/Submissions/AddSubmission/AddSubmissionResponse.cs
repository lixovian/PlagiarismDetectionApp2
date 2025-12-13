namespace FileStoringService.UseCases.Submissions.AddSubmission;

public sealed record AddSubmissionResponse(
    Guid Id,
    int StudentId,
    int AssignmentId,
    Guid StoredFileId,
    DateTime SubmittedAt
);