using FileStoringService.Entities.Models;
using FileStoringService.Infrastructure.Data.Dtos;
using Riok.Mapperly.Abstractions;

namespace FileStoringService.Infrastructure.Data;

[Mapper]
internal static partial class DataMapper
{
    /* StoredFiles */
    public static partial StoredFile ToEntity(this StoredFileDto dto);
    public static partial StoredFileDto ToDto(this StoredFile entity);

    /* Submissions */
    public static partial Submission ToEntity(this SubmissionDto dto);
    public static partial SubmissionDto ToDto(this Submission entity);
}