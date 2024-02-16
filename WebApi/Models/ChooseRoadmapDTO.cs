using AutoMapper;
using Roadmap.Application.Common.Mappings;
using Roadmap.Application.Funcs.Commands.RoadmapUser.CreateRoadmapUser;

namespace Roadmap.WebApi.Models;

public class ChooseRoadmapDTO : ImapWith<CreateRoadmapUserCommand>
{

    public Guid RoadmapId { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<ChooseRoadmapDTO, CreateRoadmapUserCommand>()
            .ForMember(com => com.RoadmapId,
                opt => opt.MapFrom(dto => dto.RoadmapId));
    }
}