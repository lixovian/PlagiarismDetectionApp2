namespace FileStoringService.Infrastructure.Data.Dtos;

public sealed record SubmissionDto(
    Guid Id,
    int StudentId,
    int AssignmentId,
    DateTime SubmittedAt,
    Guid StoredFileId
);