using FileStoringService.Entities.Models;
using Riok.Mapperly.Abstractions;

namespace FileStoringService.UseCases.Files.GetFileById;

[Mapper]
internal static partial class FileMapper
{
    public static partial GetFileByIdResponse ToDto(this StoredFile file);
}