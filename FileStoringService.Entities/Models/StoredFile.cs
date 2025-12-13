namespace FileStoringService.Entities.Models;

public class StoredFile
{
    public required Guid Id { get; init; }

    public required string Name { get; init; }
    public required long Size { get; init; }
    
    public required string Sha256 { get; init; }

    public required DateTime CreatedAt { get; init; }
}