namespace FileStoringService.UseCases.Complex.SubmitFile;

internal sealed class SubmitFileRequestHandler(ISubmitFileRepository repository) : ISubmitFileRequestHandler
{
    public SubmitFileResponse Handle(SubmitFileRequest request)
    {
        var (file, submission) = request.ToEntities();

        var result = repository.Save(file, submission);

        return result.ToResponse();
    }
}