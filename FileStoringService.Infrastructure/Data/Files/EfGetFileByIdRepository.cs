using FileStoringService.Entities.Models;
using FileStoringService.UseCases.Files.GetFileById;

namespace FileStoringService.Infrastructure.Data.Files;

internal sealed class EfGetFileByIdRepository(FileStoringDbContext dbContext) : IGetFileByIdRepository
{
    public StoredFile? GetById(Guid id)
    {
        return dbContext
            .StoredFiles
            .SingleOrDefault(f => f.Id == id)
            ?.ToEntity();
    }
}