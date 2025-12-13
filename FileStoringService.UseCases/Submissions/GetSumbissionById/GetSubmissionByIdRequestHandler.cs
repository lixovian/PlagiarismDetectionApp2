namespace FileStoringService.UseCases.Submissions.GetSubmissionById;

internal sealed class GetSubmissionByIdRequestHandler(IGetSubmissionByIdRepository repository)
    : IGetSubmissionByIdRequestHandler
{
    public GetSubmissionByIdResponse? Handle(GetSubmissionByIdRequest request)
    {
        var submission = repository.GetById(request.Id);
        return submission is null ? null : submission.ToDto();
    }
}