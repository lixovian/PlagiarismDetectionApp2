using FileStoringService.Entities.Models;
using Riok.Mapperly.Abstractions;

namespace FileStoringService.UseCases.Files.ListFiles;

[Mapper]
internal static partial class FileMapper
{
    internal static partial ListFilesResponseItem ToDto(this StoredFile file);
}