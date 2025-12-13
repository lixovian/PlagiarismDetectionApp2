using System.Net.Http.Json;
using FileAnalysisService.UseCases.Reports.CreateReport;
using FileInfo = FileAnalysisService.UseCases.Reports.CreateReport.FileInfo;

namespace FileAnalysisService.Infrastructure.Data;

internal sealed class FileStoringClient(HttpClient httpClient) : IFileStoringClient
{
    public SubmissionInfo GetSubmissionById(Guid submissionId)
    {
        // ожидаем endpoint: GET /submissions/{id}
        var result = httpClient.GetFromJsonAsync<SubmissionInfo>($"/submissions/{submissionId}")
            .GetAwaiter()
            .GetResult();

        if (result is null)
            throw new InvalidOperationException($"Submission {submissionId} not found or invalid response.");

        return result;
    }

    public FileInfo GetFileById(Guid fileId)
    {
        // ожидаем endpoint: GET /files/{id}
        var result = httpClient.GetFromJsonAsync<FileInfo>($"/files/{fileId}")
            .GetAwaiter()
            .GetResult();

        if (result is null)
            throw new InvalidOperationException($"File {fileId} not found or invalid response.");

        return result;
    }

    public IReadOnlyList<SubmissionInfo> GetSubmissionsByAssignmentId(int assignmentId)
    {
        // ожидаем endpoint: GET /submissions/assignment/{assignmentId}
        var result = httpClient.GetFromJsonAsync<List<SubmissionInfo>>($"/submissions/assignment/{assignmentId}")
            .GetAwaiter()
            .GetResult();

        return result ?? [];
    }
}