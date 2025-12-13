using ApiGateway.Entities.Models.SubmitFile;

namespace ApiGateway.UseCases.SubmitFile;

public sealed record SubmitFileRequest(
    int StudentId,
    int AssignmentId,
    string FileName,
    string Text
)
{
    public ApiGateway.Entities.Models.SubmitFile.SubmitFileRequest ToDto() =>
        new(StudentId, AssignmentId, FileName, Text);
}