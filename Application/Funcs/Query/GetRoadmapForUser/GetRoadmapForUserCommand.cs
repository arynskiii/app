using MediatR;

namespace Roadmap.Application.Funcs.Query.GetRoadmapForUser;

public class GetRoadmapForUserCommand : IRequest<GetRoadmapForUserOutput>
{
    public Guid RoadmapId { get; set; }
    public Guid UserId { get; set; }
    
}