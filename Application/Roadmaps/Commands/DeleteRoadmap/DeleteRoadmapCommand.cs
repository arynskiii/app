using MediatR;

namespace Roadmap.Application.Roadmaps.Commands.DeleteRoadmap;

public class DeleteRoadmapCommand : IRequest
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
}