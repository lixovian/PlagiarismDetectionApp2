using ApiGateway.Entities.Models.SubmitFile;

namespace ApiGateway.UseCases.SubmitFile;

public interface ISubmitFileRequestHandler
{
    SubmitFileResponse Handle(SubmitFileRequest request);
}