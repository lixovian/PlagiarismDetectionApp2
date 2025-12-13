using FileStoringService.Entities.Models;
using Riok.Mapperly.Abstractions;

namespace FileStoringService.UseCases.Submissions.GetAssignmentSubmissions;

[Mapper]
internal static partial class SubmissionMapper
{
    public static partial GetAssignmentSubmissionsResponse ToDto(this Submission submission);
}