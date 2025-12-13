using FileStoringService.Entities.Models;

namespace FileStoringService.UseCases.Files.GetFileById;

public interface IGetFileByIdRepository
{
    StoredFile? GetById(Guid id);
}