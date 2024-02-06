using MediatR;

namespace Roadmap.Application.Roadmaps.Query;

public class GetRoadmapListQuery: IRequest<RoadmapListVM>
{
    public Guid UserId
    {
        get;
        set;
    }
}