namespace FileStoringService.UseCases.Complex.SubmitFile;

public sealed record SubmitFileRequest(
    int StudentId,
    int AssignmentId,
    string FileName,
    string Text
);