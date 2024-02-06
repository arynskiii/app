using MediatR;

namespace Roadmap.Application.Roadmaps.Commands.UpdateRoadmap;

public class UpdateRoadmapCommand : IRequest<Guid>
{
    public Guid Id { get; set; }
    public Guid CategoryId { get; set; }
    public Guid UserId { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
}