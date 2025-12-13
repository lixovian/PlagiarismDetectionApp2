using FileStoringService.Entities.Models;

namespace FileStoringService.UseCases.Submissions.AddSubmission;

internal static class SubmissionMapper
{
    public static Submission ToEntity(this AddSubmissionRequest request) =>
        new Submission
        {
            Id = Guid.NewGuid(),
            StudentId = request.StudentId,
            AssignmentId = request.AssignmentId,
            StoredFileId = request.StoredFileId,
            SubmittedAt = DateTime.UtcNow
        };

    public static AddSubmissionResponse ToDto(this Submission submission) =>
        new AddSubmissionResponse(
            submission.Id,
            submission.StudentId,
            submission.AssignmentId,
            submission.StoredFileId,
            submission.SubmittedAt
        );
}