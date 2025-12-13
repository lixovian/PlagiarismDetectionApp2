using FileAnalysisService.Entities.Models;
using FileAnalysisService.UseCases.Reports.CreateReport;
using Riok.Mapperly.Abstractions;

namespace FileAnalysisService.UseCases.Reports.GetReportsByAssignmentId;

[Mapper]
internal static partial class ReportMapper
{
    public static partial CreateReportResponse ToDto(this Report report);
}