using ApiGateway.Entities.Models.SubmitFile;

namespace ApiGateway.UseCases.SubmitFile;

internal sealed class SubmitFileRequestHandler(
    IFileStoringClient fileStoringClient)
    : ISubmitFileRequestHandler
{
    public SubmitFileResponse Handle(SubmitFileRequest request)
    {
        return fileStoringClient.SubmitFile(request.ToDto());
    }
}