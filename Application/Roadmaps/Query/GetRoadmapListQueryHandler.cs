using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Roadmap.Application.Interfaces;

namespace Roadmap.Application.Roadmaps.Query;

public class GetRoadmapListQueryHandler : IRequestHandler<GetRoadmapListQuery,RoadmapListVM>
{
    private readonly IRoadmapDbContext _DbContext;
    private readonly IMapper _mapper;

    public GetRoadmapListQueryHandler(IRoadmapDbContext dbContext, IMapper mapper) =>
        (_DbContext, _mapper) = (dbContext, mapper);


    public async Task<RoadmapListVM> Handle(GetRoadmapListQuery request,CancellationToken cancellationToken)
    {
        
       
        var roadmapQuery = await _DbContext.Roadmaps.ToListAsync(cancellationToken);
        
       var roadmapVM = _mapper.Map<List<RoadmapVM>>(roadmapQuery);
       Console.WriteLine(roadmapVM);
       return new RoadmapListVM
        {
            Roadmaps = roadmapVM
        };


    }

}