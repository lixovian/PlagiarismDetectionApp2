using FileAnalysisService.UseCases.Reports.CreateReport;

namespace FileAnalysisService.UseCases.Reports.GetReportsByAssignmentId;

internal sealed class GetReportsByAssignmentIdRequestHandler(
    IFileStoringClient fileStoringClient,
    IGetReportBySubmissionIdRepository reportRepository,
    ICreateReportRequestHandler createReportHandler)
    : IGetReportsByAssignmentIdRequestHandler
{
    public IReadOnlyList<CreateReportResponse> Handle(GetReportsByAssignmentIdRequest request)
    {
        // 1) Берём submissions по assignment
        var submissions = fileStoringClient.GetSubmissionsByAssignmentId(request.AssignmentId);

        // 2) Для каждого submission собираем report:
        //    - если уже есть в БД -> отдаём
        //    - если нет -> создаём через CreateReport handler
        var results = new List<CreateReportResponse>(submissions.Count);

        foreach (var submission in submissions.OrderBy(s => s.SubmittedAt))
        {
            var existing = reportRepository.GetBySubmissionId(submission.Id);

            if (existing is not null)
            {
                results.Add(existing.ToDto());
                continue;
            }

            var created = createReportHandler.Handle(new CreateReportRequest(submission.Id));
            results.Add(created);
        }

        return results;
    }
}