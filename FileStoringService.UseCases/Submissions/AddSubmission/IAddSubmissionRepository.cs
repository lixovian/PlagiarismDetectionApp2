using FileStoringService.Entities.Models;

namespace FileStoringService.UseCases.Submissions.AddSubmission;

public interface IAddSubmissionRepository
{
    void Add(Submission submission);
}