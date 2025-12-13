using FileAnalysisService.Entities.Models;
using FileAnalysisService.Infrastructure.Data.Dtos;
using Riok.Mapperly.Abstractions;

namespace FileAnalysisService.Infrastructure.Data;

[Mapper]
internal static partial class DataMapper
{
    public static partial Report ToEntity(this ReportDto dto);
    public static partial ReportDto ToDto(this Report entity);
}