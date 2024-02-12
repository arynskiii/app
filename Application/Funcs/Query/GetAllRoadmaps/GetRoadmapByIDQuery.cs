using MediatR;
using Roadmap.Application.Roadmaps.Query;

namespace Roadmap.Application.Funcs.Query.GetRoadmapByID;

public class GetRoadmapByIDQuery : IRequest<RoadmapVM>
{
    public Guid Id { get; set; }
}