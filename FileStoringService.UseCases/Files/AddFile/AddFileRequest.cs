using FileStoringService.Entities.Models;

namespace FileStoringService.UseCases.Files.AddFile;

public sealed record AddFileRequest(
    string Name,
    long Size,
    string Sha256
);