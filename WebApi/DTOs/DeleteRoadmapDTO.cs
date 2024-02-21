using AutoMapper;
using Roadmap.Application.Common.Mappings;
using Roadmap.Application.Roadmaps.Commands.DeleteRoadmap;

namespace Roadmap.WebApi.Models;

public class DeleteRoadmapDTO: ImapWith<DeleteRoadmapCommand>
{
    public Guid Id { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<DeleteRoadmapDTO, DeleteRoadmapCommand>()
            .ForMember(roadmapCommand => roadmapCommand.Id,
                opt => opt.MapFrom(roadmapDTO => roadmapDTO.Id));
    }
}