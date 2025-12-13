using FileStoringService.Entities.Models;
using Riok.Mapperly.Abstractions;

namespace FileStoringService.UseCases.Submissions.ListSubmissions;

[Mapper]
internal static partial class SubmissionMapper
{
    internal static partial ListSubmissionsResponseItem ToDto(this Submission submission);
}