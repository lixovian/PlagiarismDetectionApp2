using FileStoringService.Entities.Models;

namespace FileStoringService.UseCases.Files.AddFile;

internal static class FileMapper
{
    public static StoredFile ToEntity(this AddFileRequest request) =>
        new StoredFile
        {
            Id = Guid.NewGuid(),
            Name = request.Name,
            Size = request.Size,
            Sha256 = request.Sha256,
            CreatedAt = DateTime.UtcNow
        };

    public static AddFileResponse ToDto(this StoredFile file) =>
        new AddFileResponse(
            file.Id,
            file.Name,
            file.Size,
            file.Sha256,
            file.CreatedAt
        );
}