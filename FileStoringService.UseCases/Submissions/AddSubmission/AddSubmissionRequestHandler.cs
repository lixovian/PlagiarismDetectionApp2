namespace FileStoringService.UseCases.Submissions.AddSubmission;

internal sealed class AddSubmissionRequestHandler : IAddSubmissionRequestHandler
{
    private readonly IAddSubmissionRepository _repository;

    public AddSubmissionRequestHandler(IAddSubmissionRepository repository)
    {
        _repository = repository;
    }

    public AddSubmissionResponse Handle(AddSubmissionRequest request)
    {
        var submission = request.ToEntity();

        _repository.Add(submission);

        return submission.ToDto();
    }
}