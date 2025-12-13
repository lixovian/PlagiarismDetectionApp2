using FileStoringService.Entities.Models;

namespace FileStoringService.UseCases.Files.GetFileById;

public sealed record GetFileByIdResponse(
    Guid Id,
    string Name,
    ContentType Type,
    long Size,
    string Sha256,
    DateTime CreatedAt
);