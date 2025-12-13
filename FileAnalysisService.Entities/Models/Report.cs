namespace FileAnalisysService.Entities.Models;

public sealed class Report
{
    public Guid Id { get; init; }
    
    public Guid SubmissionId { get; init; }

    public bool? IsPlagiarism { get; init; }
    public string? WordCloudUrl { get; init; } 
}