using FileStoringService.Entities.Models;
using FileStoringService.UseCases.Files.ListFiles;

namespace FileStoringService.Infrastructure.Data.Files;

internal sealed class EfListFilesRepository(FileStoringDbContext dbContext) : IListFilesRepository
{
    public IReadOnlyList<StoredFile> GetAll()
    {
        return [.. dbContext.StoredFiles.Select(DataMapper.ToEntity)];
    }
}