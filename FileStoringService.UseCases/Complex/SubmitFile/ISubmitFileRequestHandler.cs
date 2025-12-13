namespace FileStoringService.UseCases.Submissions.SubmitFile;

public interface ISubmitFileRequestHandler
{
    SubmitFileResponse Handle(SubmitFileRequest request);
}