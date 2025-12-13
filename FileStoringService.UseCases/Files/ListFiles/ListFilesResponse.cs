namespace FileStoringService.UseCases.Files.ListFiles;

public sealed record ListFilesResponse(
    IReadOnlyList<ListFilesResponseItem> Files
);