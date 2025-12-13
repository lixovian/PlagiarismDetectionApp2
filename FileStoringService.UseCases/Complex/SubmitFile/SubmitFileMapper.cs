using System.Security.Cryptography;
using System.Text;
using FileStoringService.Entities.Models;

namespace FileStoringService.UseCases.Submissions.SubmitFile;

internal static class SubmitFileMapper
{
    public static (StoredFile file, Submission submission) ToEntities(this SubmitFileRequest request)
    {
        var fileId = Guid.NewGuid();
        var submissionId = Guid.NewGuid();
        var now = DateTime.UtcNow;

        var textBytes = Encoding.UTF8.GetBytes(request.Text);
        var sha256 = ComputeSha256Hex(textBytes);

        var file = new StoredFile
        {
            Id = fileId,
            Name = request.FileName,
            Text = request.Text,
            Size = textBytes.Length,
            Sha256 = sha256,
            CreatedAt = now
        };

        var submission = new Submission
        {
            Id = submissionId,
            StudentId = request.StudentId,
            AssignmentId = request.AssignmentId,
            StoredFileId = fileId,
            SubmittedAt = now
        };

        return (file, submission);
    }

    public static SubmitFileResponse ToResponse(this SubmitFileResult result) =>
        new SubmitFileResponse(
            result.SubmissionId,
            result.StoredFileId,
            result.Sha256,
            result.Size,
            result.SubmittedAt
        );

    private static string ComputeSha256Hex(byte[] bytes)
    {
        var hash = SHA256.HashData(bytes);
        return Convert.ToHexString(hash).ToLowerInvariant();
    }
}