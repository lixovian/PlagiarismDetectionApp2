using FileStoringService.Entities.Models;

namespace FileStoringService.UseCases.Files.ListFiles;

public sealed record ListFilesResponseItem(
    Guid Id,
    string Name,
    long Size,
    string Text,
    string Sha256,
    DateTime CreatedAt
);