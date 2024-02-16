using MediatR;
using Roadmap.Application.Interfaces;

namespace Roadmap.Application.Funcs.Commands.Sub_Template.CreateSub_Template;

public class CreateSub_TemplateHandler: IRequestHandler<CreateSub_TemplateCommand,Guid>
{
    private readonly IAppDbContext _dbContext;

    public CreateSub_TemplateHandler(IAppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Guid> Handle(CreateSub_TemplateCommand request, CancellationToken cancellationToken)
    {
        var template = await _dbContext.Templates.FindAsync(new object[] { request.TemplateId }, cancellationToken);
        if (template == null)
        {
            throw new Exception("Uncorrect template ID");
        }

        
        var sub_temp = new Domain.Sub_Template
        {
            Title = request.Title,
            Description = request.Description,
            TemplateId = request.TemplateId,
            Flag = request.Flag
        };
        await _dbContext.SubTemplates.AddAsync(sub_temp, cancellationToken);
        await _dbContext.SaveChangesAsync(cancellationToken);
        return sub_temp.Id; 
    }

}