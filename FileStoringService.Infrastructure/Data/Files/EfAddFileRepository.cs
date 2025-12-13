using FileStoringService.Entities.Models;
using FileStoringService.UseCases.Files.AddFile;

namespace FileStoringService.Infrastructure.Data.Files;

internal sealed class EfAddFileRepository(FileStoringDbContext dbContext) : IAddFileRepository
{
    public void Add(StoredFile file)
    {
        dbContext.StoredFiles.Add(file.ToDto());
        dbContext.SaveChanges();
    }
}