using AutoMapper;
using Roadmap.Application.Common.Mappings;
using Roadmap.Application.Roadmaps.Commands.UpdateRoadmap;

namespace Roadmap.WebApi.Models;

public class UpdateRoadmapDTO : ImapWith<UpdateRoadmapCommand>
{
    public Guid Id { get; set; }
    public string Title { get; set; }
  
    public string Description { get; set; }

  
  
    public void Mapping(Profile profile)
    {
        profile.CreateMap<UpdateRoadmapDTO, UpdateRoadmapCommand>()
            .ForMember(roadmapCommand => roadmapCommand.Description,
                opt => opt.MapFrom(roadmapDTO => roadmapDTO.Description))
            .ForMember(roadmapCommand => roadmapCommand.Title,
                opt => opt.MapFrom(roadmapDTO => roadmapDTO.Title))
            .ForMember(roadmapCommand => roadmapCommand.Id,
                opt => opt.MapFrom(roadmapDTO => roadmapDTO.Id));

    }

}