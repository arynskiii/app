using AutoMapper;
using Roadmap.Application.Common.Mappings;
using Roadmap.Application.Funcs.Commands.Template.DeleteTemplate;

namespace Roadmap.WebApi.Models;

public class DeleteTemplateDTO : ImapWith<DeleteTemplateCommand>
{
    public Guid Id { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<DeleteTemplateDTO, DeleteTemplateCommand>()
            .ForMember(deleteTemplateCommand => deleteTemplateCommand.Id,
                opt => opt.MapFrom(deleteTemplateDTO => deleteTemplateDTO.Id));
    }
    
}