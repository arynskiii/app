using System.ComponentModel.DataAnnotations;
using AutoMapper;
using Roadmap.Application.Common.Mappings;
using Roadmap.Application.Funcs.Commands.Sub_Template.CreateSub_Template;

namespace Roadmap.WebApi.Models;

public class CreateSubTemplateDTO : ImapWith<CreateSub_TemplateCommand>
{
    [Required] 
    public string Title { get; set; }
    [Required] 
    public string Description { get; set; }
    [Required]
    public Guid TemplateId { get; set; }
    


    public void Mapping(Profile profile)
    {
        profile.CreateMap<CreateSubTemplateDTO, CreateSub_TemplateCommand>()
            .ForMember(SubTemplateCommand => SubTemplateCommand.Title,
                opt => opt.MapFrom(subTemplateDto => subTemplateDto.Title))
            .ForMember(SubTemplateCommand => SubTemplateCommand.Description,
                opt => opt.MapFrom(subTemplateDto => subTemplateDto.Description))
            .ForMember(SubTemplateCommand => SubTemplateCommand.TemplateId,
                opt => opt.MapFrom(subTemplateDto => subTemplateDto.TemplateId));
    }
}