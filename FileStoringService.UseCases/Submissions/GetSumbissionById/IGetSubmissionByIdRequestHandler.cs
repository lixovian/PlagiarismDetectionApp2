namespace FileStoringService.UseCases.Submissions.GetSubmissionById;

public interface IGetSubmissionByIdRequestHandler
{
    GetSubmissionByIdResponse? Handle(GetSubmissionByIdRequest request);
}