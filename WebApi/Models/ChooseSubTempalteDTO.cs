using AutoMapper;
using Roadmap.Application.Common.Mappings;
using Roadmap.Application.Funcs.Commands.SubTemplateUser.CreateSubTemplateUser;

namespace Roadmap.WebApi.Models;

public class ChooseSubTempalteDTO: ImapWith<CreateSubTemplateUserCommand>
{
    public Guid SubTemplateId { get; set; }
    public IFormFile? File { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<ChooseSubTempalteDTO, CreateSubTemplateUserCommand>()
            .ForMember(comm => comm.SubTemplateId,
                opt => opt.MapFrom(dto => dto.SubTemplateId));
    }
}