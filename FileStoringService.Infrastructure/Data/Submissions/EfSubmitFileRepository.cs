using FileStoringService.Entities.Models;
using FileStoringService.UseCases.Complex.SubmitFile;
using Microsoft.EntityFrameworkCore;

namespace FileStoringService.Infrastructure.Data.Submissions;

internal sealed class EfSubmitFileRepository(FileStoringDbContext dbContext) : ISubmitFileRepository
{
    public SubmitFileResult Save(StoredFile file, Submission submission)
    {
        using var tx = dbContext.Database.BeginTransaction();

        dbContext.StoredFiles.Add(file.ToDto());
        dbContext.Submissions.Add(submission.ToDto());

        dbContext.SaveChanges();
        tx.Commit();

        return new SubmitFileResult(
            submission.Id,
            file.Id,
            file.Sha256,
            file.Size,
            submission.SubmittedAt
        );
    }
}   