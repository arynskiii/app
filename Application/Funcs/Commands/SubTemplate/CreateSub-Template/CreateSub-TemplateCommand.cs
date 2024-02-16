using MediatR;

namespace Roadmap.Application.Funcs.Commands.Sub_Template.CreateSub_Template;

public class CreateSub_TemplateCommand :IRequest<Guid>
{
    public string Title { get; set; }
    public string Description { get; set; }
    public Guid TemplateId { get; set; }
    public bool Flag { get; set; }
    
}