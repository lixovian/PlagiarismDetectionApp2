namespace FileStoringService.UseCases.Submissions.GetAssignmentSubmissions;

public interface IGetAssignmentSubmissionsRequestHandler
{
    IReadOnlyList<GetAssignmentSubmissionsResponse> Handle(
        GetAssignmentSubmissionsRequest request);
}