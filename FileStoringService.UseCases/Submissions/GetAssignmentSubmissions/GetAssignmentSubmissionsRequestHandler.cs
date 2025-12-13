namespace FileStoringService.UseCases.Submissions.GetAssignmentSubmissions;

internal sealed class GetAssignmentSubmissionsRequestHandler(
    IGetAssignmentSubmissionsRepository repository)
    : IGetAssignmentSubmissionsRequestHandler
{
    public IReadOnlyList<GetAssignmentSubmissionsResponse> Handle(
        GetAssignmentSubmissionsRequest request)
    {
        return repository
            .GetByAssignmentId(request.AssignmentId)
            .Select(SubmissionMapper.ToDto)
            .ToList();
    }
}