using MediatR;
using Roadmap.Application.Interfaces;

namespace Roadmap.Application.Funcs.Commands.SubTemplateUser.CreateSubTemplateUser;

public class CreateSubTemplateHandler: IRequestHandler<CreateSubTemplateUserCommand,Guid>
{
    private readonly IAppDbContext _dbContext;
    public CreateSubTemplateHandler(IAppDbContext dbContext) => _dbContext = dbContext;

    public async Task<Guid> Handle(CreateSubTemplateUserCommand request, CancellationToken cancellationToken)
    {
        var subTemplate=await _dbContext.SubStages.FindAsync(request.SubTemplateId);
        if (subTemplate == null)
        {
            throw new Exception("Cannot find SubTemplate by this ID");
        }

        var SubTemplateUser = new Domain.SubStageUser() 
        {
            UserId = request.UserId,
            SubTemplateId = request.SubTemplateId
        };
        await _dbContext.SubStageUsers.AddAsync(SubTemplateUser, cancellationToken);
        await _dbContext.SaveChangesAsync(cancellationToken);
        return SubTemplateUser.Id;
    }
    
}