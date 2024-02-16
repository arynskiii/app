using MediatR;
using Roadmap.Application.Common.Exceptions;
using Roadmap.Application.Interfaces;

namespace Roadmap.Application.Funcs.Commands.Template;

public class CreateTemplateCommandHandler : IRequestHandler<CreateTemplateCommand, Guid>
{
    private readonly IAppDbContext _dbContext;


    public CreateTemplateCommandHandler(IAppDbContext dbContext)
    {
        _dbContext = dbContext;
      
    }

    public async Task<Guid> Handle(CreateTemplateCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var roadmap = await _dbContext.Roadmaps.FindAsync(new object[] { request.RoadmapId }, cancellationToken);

            if (roadmap == null)
            {
                throw new Exception("Roadmap is not found");
            }
            var template = new Domain.Template
            {
                Title = request.Title,
                Description = request.Description,
                RoadmapId = request.RoadmapId
            };

            await _dbContext.Templates.AddAsync(template, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);
            
            return template.Id;
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }
}
       
    
