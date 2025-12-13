using FileStoringService.Entities.Models;

namespace FileStoringService.UseCases.Files.AddFile;

public sealed record AddFileResponse(
    Guid Id,
    string Name,
    ContentType Type,
    long Size,
    string Sha256,
    DateTime CreatedAt
);