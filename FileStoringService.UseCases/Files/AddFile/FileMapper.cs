using System.Security.Cryptography;
using System.Text;
using FileStoringService.Entities.Models;

namespace FileStoringService.UseCases.Files.AddFile;

internal static class FileMapper
{
    public static StoredFile ToEntity(this AddFileRequest request) =>
        new StoredFile
        {
            Id = Guid.NewGuid(),
            Name = request.Name,
            Text = request.Text,
            Size = Encoding.UTF8.GetBytes(request.Text).Length,
            Sha256 = ComputeSha256Hex(request.Text),
            CreatedAt = DateTime.UtcNow
        };
    
    private static string ComputeSha256Hex(string text)
    {
        var bytes = Encoding.UTF8.GetBytes(text);
        var hash = SHA256.HashData(bytes);

        return Convert.ToHexString(hash).ToLowerInvariant();
    }

    public static AddFileResponse ToDto(this StoredFile file) =>
        new AddFileResponse(
            file.Id,
            file.Name,
            file.Size,
            file.Sha256,
            file.CreatedAt
        );
}