using FileAnalysisService.Entities.Models;

namespace FileAnalysisService.UseCases.Reports.CreateReport;

internal sealed class CreateReportRequestHandler(
    ICreateReportRepository repository,
    IFileStoringClient fileStoringClient,
    IWordCloudGenerator wordCloudGenerator)
    : ICreateReportRequestHandler
{
    public CreateReportResponse Handle(CreateReportRequest request)
    {
        var submission = fileStoringClient.GetSubmissionById(request.SubmissionId);

        var currentFile = fileStoringClient.GetFileById(submission.StoredFileId);

        var allForAssignment = fileStoringClient.GetSubmissionsByAssignmentId(submission.AssignmentId);

        var isPlagiarism = allForAssignment
            .Where(s => s.Id != submission.Id)
            .Where(s => s.StudentId != submission.StudentId)
            .Where(s => s.SubmittedAt < submission.SubmittedAt)
            .Select(s =>
            {
                var file = fileStoringClient.GetFileById(s.StoredFileId);
                return file.Sha256;
            })
            .Any(sha => sha == currentFile.Sha256);

        var file = fileStoringClient.GetFileById(submission.StoredFileId);
        var wordCloudUrl = wordCloudGenerator.Generate(file.Text);
        
        var report = new Report
        {
            Id = Guid.NewGuid(),
            SubmissionId = submission.Id,
            IsPlagiarism = isPlagiarism,
            WordCloudUrl = wordCloudUrl
        };

        repository.Add(report);

        return report.ToDto();
    }
}