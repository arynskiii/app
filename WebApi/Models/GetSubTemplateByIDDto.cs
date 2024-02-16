using AutoMapper;
using Roadmap.Application.Common.Mappings;
using Roadmap.Application.Funcs.Query.GetRoadmapByID;
using Roadmap.Application.Funcs.Query.GetSubTemplate;

namespace Roadmap.WebApi.Models;

public class GetSubTemplateByIdDto : ImapWith<GetSubTemplateCommand>
{
    public Guid Id { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<GetSubTemplateByIdDto, GetSubTemplateCommand>()
            .ForMember(comm => comm.Id,
                opt => opt.MapFrom(dto=>dto.Id));
    }
}