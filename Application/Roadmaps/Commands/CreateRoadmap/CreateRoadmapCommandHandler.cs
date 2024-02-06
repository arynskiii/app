using MediatR;
using Roadmap.Application.Interfaces;

namespace Roadmap.Application.Roadmaps.Commands.CreateRoadmap;

public class CreateRoadmapCommandHandler : IRequestHandler<CreateRoadmapCommand,Guid>
{
    private readonly IRoadmapDbContext _dbContext;
    public CreateRoadmapCommandHandler(IRoadmapDbContext dbContext) => _dbContext = dbContext;

    public async Task<Guid>Handle(CreateRoadmapCommand request, CancellationToken cancellationToken)
    {
       
        var roadmap = new Domain.Roadmap()
        {
            CategoryId = request.CategoryId,
            Description = request.Description,
            Title = request.Title,
            UserId = request.UserId
        };
    
        await _dbContext.Roadmaps.AddAsync(roadmap, cancellationToken);
        await _dbContext.SaveChangesAsync(cancellationToken);

        return roadmap.Id;
    }


}