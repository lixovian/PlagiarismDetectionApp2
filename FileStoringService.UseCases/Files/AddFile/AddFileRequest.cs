using FileStoringService.Entities.Models;

namespace FileStoringService.UseCases.Files.AddFile;

public sealed record AddFileRequest(
    string Name,
    ContentType Type,
    long Size,
    string Sha256
);