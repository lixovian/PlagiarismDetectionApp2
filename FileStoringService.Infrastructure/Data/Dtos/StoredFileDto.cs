namespace FileStoringService.Infrastructure.Data.Dtos;

public sealed record StoredFileDto(
    Guid Id,
    string Name,
    long Size,
    string Sha256,
    DateTime CreatedAt
);