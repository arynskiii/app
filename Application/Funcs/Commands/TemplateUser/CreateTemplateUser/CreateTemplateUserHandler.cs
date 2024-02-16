using MediatR;
using Roadmap.Application.Interfaces;

namespace Roadmap.Application.Funcs.Commands.TemplateUser.CreateTemplateUser;

public class CreateTemplateUserHandler : IRequestHandler<CreateTemplateUserCommand,Guid>
{
    private readonly IAppDbContext _dbContext;
    public CreateTemplateUserHandler(IAppDbContext dbContext) => _dbContext = dbContext;

    public async Task<Guid> Handle(CreateTemplateUserCommand request, CancellationToken cancellationToken)
    {
        var templateUser = new Domain.TemplateUser()
        {
            TemplateId = request.TemplateId,
            RoadmapUser = request.RoadmapUser,
          
        };
        await _dbContext.TemplateUsers.AddAsync(templateUser, cancellationToken);
        await _dbContext.SaveChangesAsync(cancellationToken);
        return templateUser.Id;
    }
    
}