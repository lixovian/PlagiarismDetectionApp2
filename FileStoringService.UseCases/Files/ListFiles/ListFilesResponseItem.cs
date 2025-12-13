using FileStoringService.Entities.Models;

namespace FileStoringService.UseCases.Files.ListFiles;

public sealed record ListFilesResponseItem(
    Guid Id,
    string Name,
    ContentType Type,
    long Size,
    string Sha256,
    DateTime CreatedAt
);