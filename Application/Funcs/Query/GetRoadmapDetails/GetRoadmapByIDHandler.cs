using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Roadmap.Application.Common.Exceptions;
using Roadmap.Application.Funcs.Query.GetRoadmapByID;
using Roadmap.Application.Interfaces;
using Roadmap.Application.Roadmaps.Query;

namespace Roadmap.Application.Funcs.Query.GetAllRoadmaps;

public class GetRoadmapByIDHandler: IRequestHandler<GetRoadmapByIDQuery,RoadmapVMDTO>
{
    private readonly IAppDbContext _DbContext;
    private readonly IMapper _mapper;

    public GetRoadmapByIDHandler(IAppDbContext dbContext, IMapper mapper) =>
        (_DbContext, _mapper) = (dbContext, mapper);


    public async Task<RoadmapVMDTO> Handle(GetRoadmapByIDQuery request, CancellationToken cancellationToken)
    {
       var roadmap= await _DbContext.Roadmaps.Include(r=>r.Templates).FirstOrDefaultAsync(q=>q.Id == request.Id, cancellationToken: cancellationToken);
       if (roadmap == null)
       {
           throw new NotFoundException(nameof(roadmap), request.Id);
       }

       var roadmapVM = _mapper.Map<RoadmapVMDTO>(roadmap);
       return roadmapVM;
    }
    
}