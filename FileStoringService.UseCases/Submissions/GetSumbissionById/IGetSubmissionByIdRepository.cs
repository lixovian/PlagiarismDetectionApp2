using FileStoringService.Entities.Models;

namespace FileStoringService.UseCases.Submissions.GetSubmissionById;

public interface IGetSubmissionByIdRepository
{
    Submission? GetById(Guid id);
}