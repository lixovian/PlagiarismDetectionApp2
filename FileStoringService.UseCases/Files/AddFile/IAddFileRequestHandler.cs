namespace FileStoringService.UseCases.Files.AddFile;

public interface IAddFileRequestHandler
{
    AddFileResponse Handle(AddFileRequest request);
}