using FileAnalysisService.Entities.Models;

namespace FileAnalysisService.UseCases.Reports.CreateReport;

internal sealed class CreateReportRequestHandler(
    ICreateReportRepository repository,
    IFileStoringClient fileStoringClient)
    : ICreateReportRequestHandler
{
    public CreateReportResponse Handle(CreateReportRequest request)
    {
        // 1) Узнаём submission (assignment, кто, когда, какой файл)
        var submission = fileStoringClient.GetSubmissionById(request.SubmissionId);

        // 2) Узнаём sha256 текущего файла
        var currentFile = fileStoringClient.GetFileById(submission.StoredFileId);

        // 3) Берём все submissions по этому assignment
        var allForAssignment = fileStoringClient.GetSubmissionsByAssignmentId(submission.AssignmentId);

        // 4) Плагиат: есть ли более ранняя submission ДРУГОГО студента с тем же sha256
        //    (если хочешь “любая более ранняя submission”, даже того же студента — убери проверку StudentId)
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

        var report = new Report
        {
            Id = Guid.NewGuid(),
            SubmissionId = submission.Id,
            IsPlagiarism = isPlagiarism,
            WordCloudUrl = null
        };

        repository.Add(report);

        return report.ToDto();
    }
}