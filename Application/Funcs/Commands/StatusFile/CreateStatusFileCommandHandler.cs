using MediatR;
using Roadmap.Application.Interfaces;

namespace Roadmap.Application.Funcs.Commands.StatusFile;

public class CreateStatusFileCommandHandler : IRequestHandler<CreateStatusFileCommand>
{
    private readonly IAppDbContext _dbContext;
 
    public CreateStatusFileCommandHandler(IAppDbContext dbContext,IFileService fileService) => _dbContext = dbContext;

    public async Task Handle(CreateStatusFileCommand request, CancellationToken cancellationToken)
    {
        var subStage = await _dbContext.SubStages.FindAsync(request.SubTemplateId);

        if (subStage == null)
        {
            throw new Exception("Cannot find subtemplate by this ID");
        }


        await _dbContext.SaveChangesAsync(cancellationToken);

        var fileStatus = new Domain.FileStatus()
        {
            SubTemplateId = request.SubTemplateId,
            UserId = request.UserId,
            Filename = request.File?.FileName,
            Flag = true
        };
        await _dbContext.FileStatus.AddAsync(fileStatus, cancellationToken);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }
}