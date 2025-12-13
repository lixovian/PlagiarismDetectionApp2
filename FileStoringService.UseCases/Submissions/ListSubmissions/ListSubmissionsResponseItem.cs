namespace FileStoringService.UseCases.Submissions.ListSubmissions;

public sealed record ListSubmissionsResponseItem(
    Guid Id,
    int StudentId,
    int AssignmentId,
    Guid StoredFileId,
    DateTime SubmittedAt
);