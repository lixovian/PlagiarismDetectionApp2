using FileStoringService.Entities.Models;
using FileStoringService.UseCases.Submissions.GetSubmissionById;

namespace FileStoringService.Infrastructure.Data.Submissions;

internal sealed class EfGetSubmissionByIdRepository(FileStoringDbContext dbContext)
    : IGetSubmissionByIdRepository
{
    public Submission? GetById(Guid id)
    {
        return dbContext.Submissions
            .SingleOrDefault(s => s.Id == id)
            ?.ToEntity();
    }
}