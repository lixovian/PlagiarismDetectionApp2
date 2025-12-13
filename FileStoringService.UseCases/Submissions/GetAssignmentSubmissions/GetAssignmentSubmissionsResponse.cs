using FileStoringService.Entities.Models;

namespace FileStoringService.UseCases.Submissions.GetAssignmentSubmissions;

public sealed record GetAssignmentSubmissionsResponse(
    Guid Id,
    int StudentId,
    int AssignmentId,
    Guid StoredFileId,
    DateTimeOffset SubmittedAt
);