using MediatR;

namespace Roadmap.Application.Funcs.Commands.Template;

public class CreateTemplateCommand : IRequest<Guid>
{
    public string Title { get; set; }
    public string Description { get; set; }
    public Guid RoadmapId { get; set; }
}