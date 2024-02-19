using MediatR;
using Microsoft.EntityFrameworkCore;
using Roadmap.Application.Interfaces;

namespace Roadmap.Application.Funcs.Commands.TemplateUser.CreateTemplateUser;

public class CreateTemplateUserHandler : IRequestHandler<CreateTemplateUserCommand,Guid>
{
    private readonly IAppDbContext _dbContext;
    public CreateTemplateUserHandler(IAppDbContext dbContext) => _dbContext = dbContext;

    public async Task<Guid> Handle(CreateTemplateUserCommand request, CancellationToken cancellationToken)
    {
        
        var roadmapInfo = await _dbContext.Roadmaps
            .Where(r => r.Templates.Any(t => t.Id == request.TemplateId))
            .Select(r => new { Id = r.Id, Title = r.Title,Description=r.Description })
            .FirstOrDefaultAsync();

        request.RoadmapUser = new Domain.RoadmapUser()
        {
            UserId = request.RoadmapUser.UserId,
            Description = roadmapInfo.Description,
            Title = roadmapInfo.Title,
            RoadmapId = roadmapInfo.Id
        };
       
        
        var templateUser = new Domain.StageUser()
        {
            TemplateId = request.TemplateId,
            RoadmapUser = request.RoadmapUser,
          
        };
        await _dbContext.StageUsers.AddAsync(templateUser, cancellationToken);
        await _dbContext.SaveChangesAsync(cancellationToken);
        return templateUser.Id;
    }
    
}