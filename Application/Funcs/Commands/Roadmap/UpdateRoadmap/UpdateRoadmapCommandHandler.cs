using MediatR;
using Microsoft.EntityFrameworkCore;
using Roadmap.Application.Common.Exceptions;
using Roadmap.Application.Interfaces;

namespace Roadmap.Application.Roadmaps.Commands.UpdateRoadmap;

public class UpdateRoadmapCommandHandler : IRequestHandler<UpdateRoadmapCommand,Guid>
{
    private readonly IAppDbContext _dbContext;
    public UpdateRoadmapCommandHandler(IAppDbContext dbContext) => _dbContext = dbContext;

    public async Task<Guid> Handle(UpdateRoadmapCommand request, CancellationToken cancellationToken)
    {
        var entity = await _dbContext.Roadmaps.FirstOrDefaultAsync(rdmp => rdmp.Id == request.Id, cancellationToken);
        if (entity == null )
        {
            throw new NotFoundException(nameof(Roadmap), request.Id);

        }

        entity.Description = request.Description;
        entity.Title = request.Title;
        await _dbContext.SaveChangesAsync(cancellationToken);
        return entity.Id;
    }

}