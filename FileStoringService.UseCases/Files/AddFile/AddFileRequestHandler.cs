namespace FileStoringService.UseCases.Files.AddFile;

internal sealed class AddFileRequestHandler : IAddFileRequestHandler
{
    private readonly IAddFileRepository _repository;

    public AddFileRequestHandler(IAddFileRepository repository)
    {
        _repository = repository;
    }

    public AddFileResponse Handle(AddFileRequest request)
    {
        var file = request.ToEntity();

        _repository.Add(file);

        return file.ToDto();
    }
}