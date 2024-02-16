using System.ComponentModel.DataAnnotations;
using AutoMapper;
using Roadmap.Application.Common.Mappings;
using Roadmap.Application.Roadmaps.Commands.CreateRoadmap;

namespace Roadmap.WebApi.Models;
public class CreateRoadmapDTO : ImapWith<CreateRoadmapCommand>
{
        [Required]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
  
        [Required]
        public Guid CategoryId { get; set; }
        
        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateRoadmapDTO, CreateRoadmapCommand>()
                .ForMember(roadmapCommand => roadmapCommand.Description,
                    opt => opt.MapFrom(roadmapDTO => roadmapDTO.Description))
                .ForMember(roadmapCommand => roadmapCommand.Title,
                    opt => opt.MapFrom(roadmapDTO => roadmapDTO.Title))
                .ForMember(roadmapCommand => roadmapCommand.CategoryId,
                    opt => opt.MapFrom(dto => dto.CategoryId));

        }

}