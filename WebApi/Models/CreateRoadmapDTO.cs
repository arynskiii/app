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
        
        public IFormFile File { get; set; }
        public Guid CategoryId { get; set; } 
        
 

      
      
        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateRoadmapDTO, CreateRoadmapCommand>()
                .ForMember(roadmapCommand => roadmapCommand.Description,
                    opt => opt.MapFrom(roadmapDTO => roadmapDTO.Description))
                .ForMember(roadmapCommand => roadmapCommand.Title,
                    opt => opt.MapFrom(roadmapDTO => roadmapDTO.Title))
                .ForMember(roadmapCommand => roadmapCommand.File,
                    opt => opt.MapFrom(roadmapDTO => roadmapDTO.File))
                .ForMember(opt => opt.CategoryId,
                    opt=>opt.MapFrom(dto=>dto.CategoryId));
        }

}