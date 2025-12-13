namespace FileStoringService.UseCases.Submissions.SubmitFile;

public sealed record SubmitFileRequest(
    int StudentId,
    int AssignmentId,
    string FileName,
    string Text
);