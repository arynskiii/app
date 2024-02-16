using MediatR;
using Microsoft.AspNetCore.Http;

namespace Roadmap.Application.Roadmaps.Commands.CreateRoadmap;

public class CreateRoadmapCommand :  IRequest<Guid>
{
    public string Title { get; set; }
    public string Description { get; set; }
    
    public Guid CategoryId { get; set; }
    public Guid UserId { get; set; }
}