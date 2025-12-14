namespace FileAnalysisService.UseCases.Reports.CreateReport;

public interface IFileStoringClient
{
    SubmissionInfo GetSubmissionById(Guid submissionId);
    FileInfo GetFileById(Guid fileId);
    IReadOnlyList<SubmissionInfo> GetSubmissionsByAssignmentId(int assignmentId);
}

public sealed record SubmissionInfo(
    Guid Id,
    int AssignmentId,
    int StudentId,
    Guid StoredFileId,
    DateTime SubmittedAt
);

public sealed record FileInfo(
    Guid Id,
    string Text,
    string Sha256
);