using MediatR;
using Roadmap.Application.Roadmaps.Query;

namespace Roadmap.Application.Funcs.Query.GetRoadmapByID;

public class GetRoadmapByIDQuery : IRequest<RoadmapVMDTO>
{
    public Guid Id { get; set; }
    
    public Guid UserId { get; set; }
}