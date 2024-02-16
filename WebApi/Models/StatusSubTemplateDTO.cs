using AutoMapper;
using Roadmap.Application.Common.Mappings;
using Roadmap.Application.Funcs.Commands.StatusFile;

namespace Roadmap.WebApi.Models;

public class StatusSubTemplateDTO: ImapWith<CreateStatusFileCommand>
{
    public IFormFile File { get; set; }
    public Guid SubTemplateId { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<StatusSubTemplateDTO, CreateStatusFileCommand>()
            .ForMember(com => com.SubTemplateId,
                opt => opt.MapFrom(dto => dto.SubTemplateId))
            .ForMember(com => com.File,
                opt => opt.MapFrom(dto => dto.File));
    }
}