using System.ComponentModel.DataAnnotations;
using AutoMapper;
using Roadmap.Application.Common.Mappings;
using Roadmap.Application.Funcs.Commands.Template;

namespace Roadmap.WebApi.Models;

public class CreateTemplateDTO : ImapWith<CreateTemplateCommand>
{
    [Required]
    public string Title { get; set; }
    [Required]
    public string Description { get; set; }
    
    [Required]
    public Guid RoadmapId { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<CreateTemplateDTO, CreateTemplateCommand>()
            .ForMember(templateCommand => templateCommand.Title,
                opt => opt.MapFrom(templateDTO => templateDTO.Title))
            .ForMember(templateCommand => templateCommand.Description,
                opt => opt.MapFrom(templateDTO => templateDTO.Description))
            .ForMember(templateCommand => templateCommand.RoadmapId,
                opt => opt.MapFrom(templateDTO => templateDTO.RoadmapId));
    }
}