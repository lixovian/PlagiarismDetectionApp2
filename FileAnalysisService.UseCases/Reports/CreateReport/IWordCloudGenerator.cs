namespace FileAnalysisService.UseCases.Reports.CreateReport;

public interface IWordCloudGenerator
{
    public string Generate(string text);
}