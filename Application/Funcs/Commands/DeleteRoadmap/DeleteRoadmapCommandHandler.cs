using MediatR;
using Microsoft.EntityFrameworkCore;
using Roadmap.Application.Common.Exceptions;
using Roadmap.Application.Interfaces;


namespace Roadmap.Application.Roadmaps.Commands.DeleteRoadmap;

public class DeleteRoadmapCommandHandler : IRequestHandler<DeleteRoadmapCommand>
{
    private readonly IRoadmapDbContext _DbContext;
    public DeleteRoadmapCommandHandler(IRoadmapDbContext dbContext) => _DbContext = dbContext;

    public async Task Handle(DeleteRoadmapCommand request, CancellationToken cancellationToken)
    {
      var entity= await _DbContext.Roadmaps.FirstOrDefaultAsync(rdmp => rdmp.Id == request.Id, cancellationToken);
      if (entity == null || entity.UserId != request.UserId)
      {
          throw new NotFoundException(nameof(Domain.Roadmap), cancellationToken);
      }

      _DbContext.Roadmaps.Remove(entity);
      await  _DbContext.SaveChangesAsync(cancellationToken);
    }


}