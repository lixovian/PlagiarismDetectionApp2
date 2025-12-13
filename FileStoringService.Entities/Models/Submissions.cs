namespace FileStoringService.Entities.Models;

public sealed class Submission
{
    public Guid Id { get; init; }

    public int StudentId { get; init; }
    public int AssignmentId { get; init; }

    public DateTime SubmittedAt { get; init; }

    public Guid StoredFileId { get; init; }
}