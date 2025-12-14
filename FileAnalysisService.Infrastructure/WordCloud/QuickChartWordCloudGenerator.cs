using System.Text.Json;
using FileAnalysisService.UseCases.Reports.CreateReport;

namespace FileAnalysisService.Infrastructure.WordCloud;

internal sealed class QuickChartWordCloudGenerator : IWordCloudGenerator
{
    public string Generate(string text)
    {
        var payload = new
        {
            format = "png",
            width = 500,
            height = 500,
            fontScale = 15,
            removeStopwords = true,
            text
        };

        var json = JsonSerializer.Serialize(payload);

        var encoded = Uri.EscapeDataString(json);

        return $"https://quickchart.io/wordcloud?c={encoded}";
    }
}