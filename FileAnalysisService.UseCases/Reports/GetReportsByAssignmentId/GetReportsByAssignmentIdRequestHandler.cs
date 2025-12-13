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
        var submissions = fileStoringClient.GetSubmissionsByAssignmentId(request.AssignmentId);

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