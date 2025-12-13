using FileAnalysisService.Entities.Models;
using Riok.Mapperly.Abstractions;

namespace FileAnalysisService.UseCases.Reports.CreateReport;

[Mapper]
internal static partial class ReportMapper
{
    public static partial CreateReportResponse ToDto(this Report report);
}