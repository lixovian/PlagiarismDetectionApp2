namespace FileStoringService.UseCases.Complex.SubmitFile;

public interface ISubmitFileRequestHandler
{
    SubmitFileResponse Handle(SubmitFileRequest request);
}