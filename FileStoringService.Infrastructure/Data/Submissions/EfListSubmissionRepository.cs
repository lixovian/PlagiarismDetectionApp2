using FileStoringService.Entities.Models;
using FileStoringService.UseCases.Submissions.ListSubmissions;

namespace FileStoringService.Infrastructure.Data.Submissions;

internal sealed class EfListSubmissionsRepository(FileStoringDbContext dbContext) : IListSubmissionsRepository
{
    public IReadOnlyList<Submission> GetAll()
    {
        return [.. dbContext.Submissions.Select(DataMapper.ToEntity)];
    }
}