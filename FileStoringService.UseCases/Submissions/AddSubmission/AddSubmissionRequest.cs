namespace FileStoringService.UseCases.Submissions.AddSubmission;

public sealed record AddSubmissionRequest(
    int StudentId,
    int AssignmentId,
    Guid StoredFileId
);