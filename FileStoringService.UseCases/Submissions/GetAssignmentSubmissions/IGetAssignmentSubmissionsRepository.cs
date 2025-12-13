using FileStoringService.Entities.Models;

namespace FileStoringService.UseCases.Submissions.GetAssignmentSubmissions;

public interface IGetAssignmentSubmissionsRepository
{
    IReadOnlyList<Submission> GetByAssignmentId(int assignmentId);
}