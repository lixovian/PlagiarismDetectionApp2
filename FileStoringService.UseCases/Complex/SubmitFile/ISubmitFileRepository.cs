using FileStoringService.Entities.Models;

namespace FileStoringService.UseCases.Complex.SubmitFile;

public interface ISubmitFileRepository
{
    SubmitFileResult Save(StoredFile file, Submission submission);
}

public sealed record SubmitFileResult(
    Guid SubmissionId,
    Guid StoredFileId,
    string Sha256,
    long Size,
    DateTime SubmittedAt
);