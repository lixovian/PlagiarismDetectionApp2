namespace FileStoringService.UseCases.Files.ListFiles;

internal sealed class ListFilesRequestHandler : IListFilesRequestHandler
{
    private readonly IListFilesRepository _repository;

    public ListFilesRequestHandler(IListFilesRepository repository)
    {
        _repository = repository;
    }

    public ListFilesResponse Handle()
    {
        var files = _repository.GetAll();

        return new ListFilesResponse(files.Select(FileMapper.ToDto).ToList());
    }
}