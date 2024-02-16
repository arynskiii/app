using AutoMapper;
using MediatR;
using Roadmap.Application.Interfaces;

namespace Roadmap.Application.Funcs.Query.GetRoadmapForUser;

public class GetRoadmapForUserHandler : IRequestHandler<GetRoadmapForUserCommand,GetRoadmapForUserOutput>
{
    private readonly IAppDbContext _DbContext;
    private readonly IMapper _mapper;

    public GetRoadmapForUserHandler(IAppDbContext dbContext, IMapper mapper) =>
        (_DbContext, _mapper) = (dbContext, mapper);

    public async Task<GetRoadmapForUserOutput> Handle(GetRoadmapForUserCommand request,
        CancellationToken cancellationToken)
    {
        var roadmap = await _DbContext.RoadmapUs.FindAsync(request.RoadmapId);
        
        if (roadmap == null)
        {
            throw new Exception("Can not find roadmap");
        }

        var VmVersion = _mapper.Map<GetRoadmapForUserOutput>(roadmap);
        return VmVersion;
    }
}