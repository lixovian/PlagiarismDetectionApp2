using ApiGateway.Entities.Models.SubmitFile;

namespace ApiGateway.UseCases.SubmitFile;

public interface IFileStoringClient
{
    SubmitFileResponse SubmitFile(
        ApiGateway.Entities.Models.SubmitFile.SubmitFileRequest request);
}