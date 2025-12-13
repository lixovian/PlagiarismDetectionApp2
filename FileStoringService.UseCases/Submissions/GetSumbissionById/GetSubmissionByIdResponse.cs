namespace FileStoringService.UseCases.Submissions.GetSubmissionById;

public sealed record GetSubmissionByIdResponse(
    Guid Id,
    int StudentId,
    int AssignmentId,
    Guid StoredFileId,
    DateTime SubmittedAt
);