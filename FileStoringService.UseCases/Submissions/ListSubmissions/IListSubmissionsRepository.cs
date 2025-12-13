using FileStoringService.Entities.Models;

namespace FileStoringService.UseCases.Submissions.ListSubmissions;

public interface IListSubmissionsRepository
{
    IReadOnlyList<Submission> GetAll();
}