using MediatR;
using Roadmap.Application.Interfaces;

namespace Roadmap.Application.Roadmaps.Commands.CreateRoadmap;

public class CreateRoadmapCommandHandler : IRequestHandler<CreateRoadmapCommand,Guid>
{
    private readonly IAppDbContext _dbContext;
    public CreateRoadmapCommandHandler(IAppDbContext dbContext) => _dbContext = dbContext;

    public async Task<Guid>Handle(CreateRoadmapCommand request, CancellationToken cancellationToken)
    {
       
        var roadmap = new Domain.Roadmap()
        {
           
            Description = request.Description,
            Title = request.Title,
            CategoryId = request.CategoryId
        };
        await _dbContext.Roadmaps.AddAsync(roadmap, cancellationToken);
        await _dbContext.SaveChangesAsync(cancellationToken);

        return roadmap.Id;
    }


}