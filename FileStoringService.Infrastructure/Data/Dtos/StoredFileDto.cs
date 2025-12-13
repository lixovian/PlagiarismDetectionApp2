namespace FileStoringService.Infrastructure.Data.Dtos;

public sealed record StoredFileDto(
    Guid Id,
    string Name,
    int Type,
    long Size,
    string Sha256,
    DateTime CreatedAt
);