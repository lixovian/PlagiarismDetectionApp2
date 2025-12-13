using FileStoringService.Entities.Models;

namespace FileStoringService.UseCases.Files.ListFiles;

public interface IListFilesRepository
{
    IReadOnlyList<StoredFile> GetAll();
}