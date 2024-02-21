using MediatR;
using Roadmap.Application.Common.Exceptions;
using Roadmap.Application.Interfaces;

namespace Roadmap.Application.Funcs.Commands.Template.DeleteTemplate;

public class DeleteTemplateCommandHandler : IRequestHandler<DeleteTemplateCommand>
{
    private readonly IAppDbContext _dbContext;
    public DeleteTemplateCommandHandler(IAppDbContext dbContext) => _dbContext = dbContext;


    public async Task Handle(DeleteTemplateCommand request, CancellationToken cancellationToken)
    {
        var template = await _dbContext.Stages.FindAsync(new object[] { request.Id }, cancellationToken);
        if (template == null)
        {
            throw new NotFoundException(nameof(Domain.Stage), cancellationToken);
        }

        _dbContext.Stages.Remove(template);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }
}