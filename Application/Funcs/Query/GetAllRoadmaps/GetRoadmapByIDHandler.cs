using AutoMapper;
using MediatR;
using Roadmap.Application.Common.Exceptions;
using Roadmap.Application.Funcs.Query.GetRoadmapByID;
using Roadmap.Application.Interfaces;
using Roadmap.Application.Roadmaps.Query;

namespace Roadmap.Application.Funcs.Query.GetAllRoadmaps;

public class GetRoadmapByIDHandler: IRequestHandler<GetRoadmapByIDQuery,RoadmapVM>
{
    private readonly IAppDbContext _DbContext;
    private readonly IMapper _mapper;

    public GetRoadmapByIDHandler(IAppDbContext dbContext, IMapper mapper) =>
        (_DbContext, _mapper) = (dbContext, mapper);


    public async Task<RoadmapVM> Handle(GetRoadmapByIDQuery request, CancellationToken cancellationToken)
    {
       var roadmap= await _DbContext.Roadmaps.FindAsync(request.Id);
       if (roadmap == null)
       {
           throw new NotFoundException(nameof(roadmap), request.Id);
       }

       var roadmapVM = _mapper.Map<RoadmapVM>(roadmap);
       return roadmapVM;
    }
    
}