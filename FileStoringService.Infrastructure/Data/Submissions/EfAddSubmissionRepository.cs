using FileStoringService.Entities.Models;
using FileStoringService.UseCases.Submissions.AddSubmission;

namespace FileStoringService.Infrastructure.Data.Submissions;

internal sealed class EfAddSubmissionRepository(FileStoringDbContext dbContext) : IAddSubmissionRepository
{
    public void Add(Submission submission)
    {
        dbContext.Submissions.Add(submission.ToDto());
        dbContext.SaveChanges();
    }
}