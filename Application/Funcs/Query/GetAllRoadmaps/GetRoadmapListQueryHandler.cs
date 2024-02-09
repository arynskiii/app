using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Roadmap.Application.Interfaces;

namespace Roadmap.Application.Roadmaps.Query;

public class GetRoadmapListQueryHandler : IRequestHandler<GetRoadmapListQuery,RoadmapListVM>
{
    private readonly IAppDbContext _DbContext;
    private readonly IMapper _mapper;

    public GetRoadmapListQueryHandler(IAppDbContext dbContext, IMapper mapper) =>
        (_DbContext, _mapper) = (dbContext, mapper);


    public async Task<RoadmapListVM> Handle(GetRoadmapListQuery request,CancellationToken cancellationToken)
    {
        var roadmapQuery = await _DbContext.Roadmaps.ToListAsync(cancellationToken);
        
       var roadmapVM = _mapper.Map<List<RoadmapVM>>(roadmapQuery);
       return new RoadmapListVM
        {
            Roadmaps = roadmapVM
        };


    }

}