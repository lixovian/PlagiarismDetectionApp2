using FileStoringService.Entities.Models;
using Riok.Mapperly.Abstractions;

namespace FileStoringService.UseCases.Submissions.GetSubmissionById;

[Mapper]
internal static partial class SubmissionMapper
{
    public static partial GetSubmissionByIdResponse ToDto(this Submission submission);
}