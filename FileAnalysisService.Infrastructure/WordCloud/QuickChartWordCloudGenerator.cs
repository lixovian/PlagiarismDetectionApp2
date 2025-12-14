using System.Text.Json;
using FileAnalysisService.UseCases.Reports.CreateReport;

namespace FileAnalysisService.Infrastructure.WordCloud;

internal sealed class QuickChartWordCloudGenerator : IWordCloudGenerator
{
    public string Generate(string text)
    {
        return $"https://quickchart.io/wordcloud?text=\"{text}\"";
    }
}