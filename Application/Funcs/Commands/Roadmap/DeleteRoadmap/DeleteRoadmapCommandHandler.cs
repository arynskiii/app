using MediatR;
using Microsoft.EntityFrameworkCore;
using Roadmap.Application.Common.Exceptions;
using Roadmap.Application.Interfaces;


namespace Roadmap.Application.Roadmaps.Commands.DeleteRoadmap;

public class DeleteRoadmapCommandHandler : IRequestHandler<DeleteRoadmapCommand>
{
    private readonly IAppDbContext _DbContext;
    public DeleteRoadmapCommandHandler(IAppDbContext dbContext) => _DbContext = dbContext;

    public async Task Handle(DeleteRoadmapCommand request, CancellationToken cancellationToken)
    {
        var entity = await _DbContext.Roadmaps.FindAsync(new object[] { request.Id }, cancellationToken);
        if (entity == null)
        {
            throw new NotFoundException(nameof(Domain.Roadmap), cancellationToken);
        }

        _DbContext.Roadmaps.Remove(entity);
        await _DbContext.SaveChangesAsync(cancellationToken);
    }
}