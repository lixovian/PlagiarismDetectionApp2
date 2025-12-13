namespace FileStoringService.UseCases.Files.GetFileById;

public interface IGetFileByIdRequestHandler
{
    GetFileByIdResponse? Handle(GetFileByIdRequest request);
}