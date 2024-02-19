using AutoMapper;
using Roadmap.Application.Common.Mappings;
using Roadmap.Application.Funcs.Commands.Template;
using Roadmap.Application.Funcs.Commands.TemplateUser.CreateTemplateUser;
using Roadmap.Domain;

namespace Roadmap.WebApi.Models;

public class ChooseTemplateDTO : ImapWith<CreateTemplateUserCommand>
{
    public  Guid TemplateId { get; set; }


    public void Mapping(Profile profile)
    {
        profile.CreateMap<ChooseTemplateDTO, CreateTemplateUserCommand>()
            .ForMember(com => com.TemplateId,
                opt => opt.MapFrom(dto => dto.TemplateId));

    }
}