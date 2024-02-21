using MediatR;
using Microsoft.Extensions.Configuration;
using Roadmap.Application.Funcs.Commands.StatusFile;
using Roadmap.Application.Interfaces;
using Minio;
using Minio.DataModel.Args;

namespace Roadmap.Application.Funcs.Commands.SendFile;

public class SendFileCommandHandler : IRequestHandler<SendFileCommand>
{
    private readonly IAppDbContext _dbContext;
    private readonly IFileService _fileService;
    public SendFileCommandHandler(IAppDbContext dbContext,IFileService fileService) => (_dbContext,_fileService) = (dbContext,fileService);


    public async Task Handle(SendFileCommand request, CancellationToken cancellationToken)
    {
        _fileService.UploadFile(request.File);
    }
}