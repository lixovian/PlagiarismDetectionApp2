using FileStoringService.Entities.Models;
using FileStoringService.UseCases.Submissions.GetAssignmentSubmissions;

namespace FileStoringService.Infrastructure.Data.Submissions;

internal sealed class EfGetAssignmentSubmissionsRepository(FileStoringDbContext dbContext)
    : IGetAssignmentSubmissionsRepository
{
    public IReadOnlyList<Submission> GetByAssignmentId(int assignmentId)
    {
        return dbContext.Submissions
            .Where(s => s.AssignmentId == assignmentId)
            .Select(DataMapper.ToEntity)
            .ToList();
    }
}