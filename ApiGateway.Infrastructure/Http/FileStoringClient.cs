using System.Net.Http.Json;
using ApiGateway.Entities.Models.SubmitFile;
using ApiGateway.UseCases.SubmitFile;

namespace ApiGateway.Infrastructure.Http;

internal sealed class FileStoringClient(HttpClient httpClient) : IFileStoringClient
{
    public SubmitFileResponse SubmitFile(Entities.Models.SubmitFile.SubmitFileRequest request)
    {
        var response = httpClient.PostAsJsonAsync("/complex/submit-file", request)
            .GetAwaiter()
            .GetResult();

        if (!response.IsSuccessStatusCode)
        {
            var body = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
            throw new InvalidOperationException($"FileStoringService returned {(int)response.StatusCode}: {body}");
        }

        var result = response.Content.ReadFromJsonAsync<SubmitFileResponse>()
            .GetAwaiter()
            .GetResult();

        if (result is null)
            throw new InvalidOperationException("FileStoringService returned empty response for SubmitFile.");

        return result;
    }
}