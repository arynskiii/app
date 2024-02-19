using AutoMapper;
using Roadmap.Application.Common.Mappings;
using Roadmap.Application.Funcs.Query.GetRoadmapByID;
using Roadmap.Application.Funcs.Query.GetTemplate;

namespace Roadmap.WebApi.Models;

public class GetTemplateByIdDTO : ImapWith<GetTemplateCommand>
{
    public Guid TemplateId { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<GetTemplateByIdDTO, GetTemplateCommand>()
            .ForPath(com => com.Id,
                opt => opt.MapFrom(dto => dto.TemplateId));
    }
}