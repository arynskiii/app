using AutoMapper;
using Roadmap.Application.Common.Mappings;
using Roadmap.Application.Funcs.Query.GetRoadmapByID;

namespace Roadmap.WebApi.Models;

public class GetRoadmapByIDDTO : ImapWith<GetRoadmapByIDQuery>
{
    public Guid Id { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<GetRoadmapByIDDTO, GetRoadmapByIDQuery>()
            .ForMember(roadmapCommand => roadmapCommand.Id,
                opt => opt.MapFrom(roadmapdto => roadmapdto.Id));
    }
}