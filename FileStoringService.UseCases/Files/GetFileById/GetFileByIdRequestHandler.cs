namespace FileStoringService.UseCases.Files.GetFileById;

internal sealed class GetFileByIdRequestHandler(IGetFileByIdRepository repository)
    : IGetFileByIdRequestHandler
{
    public GetFileByIdResponse? Handle(GetFileByIdRequest request)
    {
        return repository.GetById(request.Id)?.ToDto();
    }
}