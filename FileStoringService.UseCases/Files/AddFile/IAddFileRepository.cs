using FileStoringService.Entities.Models;

namespace FileStoringService.UseCases.Files.AddFile;

public interface IAddFileRepository
{
    void Add(StoredFile file);
}