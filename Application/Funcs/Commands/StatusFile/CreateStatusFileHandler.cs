using MediatR;
using Roadmap.Application.Interfaces;

namespace Roadmap.Application.Funcs.Commands.StatusFile;

public class CreateStatusFileHandler : IRequestHandler<CreateStatusFileCommand,Guid>
{
    private readonly IAppDbContext _dbContext;
    public CreateStatusFileHandler(IAppDbContext dbContext) => _dbContext = dbContext;

    public async Task<Guid> Handle(CreateStatusFileCommand request, CancellationToken cancellationToken)
    {
    var SubTemplate=    await _dbContext.SubTemplates.FindAsync(request.SubTemplateId);
    
    if (SubTemplate == null)
    {
        throw new Exception("Cannot find subtemplate by this ID");
    }

    SubTemplate.Flag = true;
    await _dbContext.SaveChangesAsync(cancellationToken);

    var fileStatus = new Domain.FileStatus()
    {
        SubTemplateId = request.SubTemplateId,
        UserId = request.UserId,
        Filename = request.File?.FileName,
    };
    await _dbContext.FileStatus.AddAsync(fileStatus,cancellationToken);
    await _dbContext.SaveChangesAsync(cancellationToken);
    return fileStatus.Id;
    }
    
}