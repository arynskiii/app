using MediatR;

namespace Roadmap.Application.Funcs.Commands.RoadmapUser.CreateRoadmapUser;

public class CreateRoadmapUserCommand : IRequest<Guid>
{
    public Guid RoadmapId { get; set; }
    public Guid UserId { get; set; }
}