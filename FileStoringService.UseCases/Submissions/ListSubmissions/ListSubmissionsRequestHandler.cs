namespace FileStoringService.UseCases.Submissions.ListSubmissions;

internal sealed class ListSubmissionsRequestHandler : IListSubmissionsRequestHandler
{
    private readonly IListSubmissionsRepository _repository;

    public ListSubmissionsRequestHandler(IListSubmissionsRepository repository)
    {
        _repository = repository;
    }

    public ListSubmissionsResponse Handle()
    {
        var submissions = _repository.GetAll();

        return new ListSubmissionsResponse(submissions.Select(SubmissionMapper.ToDto).ToList());
    }
}