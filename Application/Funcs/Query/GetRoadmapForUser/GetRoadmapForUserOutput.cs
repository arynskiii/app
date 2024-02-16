using AutoMapper;
using Roadmap.Application.Common.Mappings;

namespace Roadmap.Application.Funcs.Query.GetRoadmapForUser;

public class GetRoadmapForUserOutput : ImapWith<Domain.RoadmapUser>
{
 
    public Guid UserId { get; set; }
    public Guid RoadmapId { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<Domain.RoadmapUser, GetRoadmapForUserCommand>()
            .ForMember(rdmVM => rdmVM.UserId,
                opt => opt.MapFrom(dto => dto.UserId))
            .ForMember(rdmVM => rdmVM.RoadmapId,
                opt => opt.MapFrom(dto => dto.RoadmapId));
    }
}