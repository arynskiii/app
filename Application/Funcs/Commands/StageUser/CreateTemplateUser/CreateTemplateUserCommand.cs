using MediatR;

namespace Roadmap.Application.Funcs.Commands.TemplateUser.CreateTemplateUser;

public class CreateTemplateUserCommand : IRequest<Guid>
{
    public Domain.RoadmapUser RoadmapUser { get; set; }
    public Guid TemplateId { get; set; }
}