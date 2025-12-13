namespace FileStoringService.UseCases.Submissions.AddSubmission;

public interface IAddSubmissionRequestHandler
{
    AddSubmissionResponse Handle(AddSubmissionRequest request);
}