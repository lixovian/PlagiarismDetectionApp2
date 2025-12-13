using System.Net.Http.Json;
using ApiGateway.Entities.Models.Reports;
using ApiGateway.UseCases.Reports;

namespace ApiGateway.Infrastructure.Http;

internal sealed class FileAnalysisClient(HttpClient httpClient) : IFileAnalysisClient
{
    public CreateReportResponse CreateReport(CreateReportRequest request)
    {
        // ожидаем endpoint: POST /reports
        var response = httpClient.PostAsJsonAsync("/reports", request)
            .GetAwaiter()
            .GetResult();

        if (!response.IsSuccessStatusCode)
        {
            var body = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
            throw new InvalidOperationException($"FileAnalysisService returned {(int)response.StatusCode}: {body}");
        }

        var result = response.Content.ReadFromJsonAsync<CreateReportResponse>()
            .GetAwaiter()
            .GetResult();

        if (result is null)
            throw new InvalidOperationException("FileAnalysisService returned empty response for CreateReport.");

        return result;
    }

    public IReadOnlyList<ReportDto> GetReportsByAssignmentId(int assignmentId)
    {
        // ожидаем endpoint: GET /reports/assignment/{assignmentId}
        var result = httpClient.GetFromJsonAsync<List<ReportDto>>($"/reports/assignment/{assignmentId}")
            .GetAwaiter()
            .GetResult();

        return result ?? [];
    }
}