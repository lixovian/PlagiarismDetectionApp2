namespace FileStoringService.UseCases.Submissions.ListSubmissions;

public sealed record ListSubmissionsResponse(
    IReadOnlyList<ListSubmissionsResponseItem> Submissions
);