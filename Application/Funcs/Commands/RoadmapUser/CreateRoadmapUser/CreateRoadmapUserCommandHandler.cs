using MediatR;
using Roadmap.Application.Interfaces;
using Roadmap.Domain;

namespace Roadmap.Application.Funcs.Commands.RoadmapUser.CreateRoadmapUser;

public class CreateRoadmapUserCommandHandler : IRequestHandler<CreateRoadmapUserCommand, Guid>
{
    private readonly IAppDbContext _dbContext;
    public CreateRoadmapUserCommandHandler(IAppDbContext dbContext) => _dbContext = dbContext;

    public async Task<Guid> Handle(CreateRoadmapUserCommand request, CancellationToken cancellationToken)
    {
        var roadmap = await _dbContext.Roadmaps.FindAsync(request.RoadmapId);
        if (roadmap == null)
        {
            throw new Exception("Cannot find roadmap by this ID");
        }

        var rdmpUser = new Domain.RoadmapUser
        {
            UserId = request.UserId,
            RoadmapId = request.RoadmapId,
            Title = roadmap.Title,
            Description = roadmap.Description
        };
        await _dbContext.RoadmapUs.AddAsync(rdmpUser, cancellationToken);
        await _dbContext.SaveChangesAsync(cancellationToken);
        return rdmpUser.Id;
    }
}