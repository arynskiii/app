using AutoMapper;
using Roadmap.Application.Common.Mappings;
using Roadmap.Application.Dtos.SubTemplate;
using Roadmap.Application.Dtos.Template;
using Roadmap.Domain;

namespace Roadmap.Application.Funcs.Query.GetTemplate;

public class GetTemplateOutput : ImapWith<Domain.Template>
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public List<SubTemplateGetDto> SubTemplates { get; set; }


    public void Mapping(Profile profile)
    {
        profile.CreateMap<Domain.Template, GetTemplateOutput>()
            .ForMember(Vm => Vm.Id,
                opt => opt.MapFrom(src => src.Id))
            .ForMember(Vm => Vm.Title,
                opt => opt.MapFrom(src => src.Title))
            .ForMember(Vm => Vm.Description,
                opt => opt.MapFrom(src => src.Description))
            .ForMember(Vm => Vm.SubTemplates,
                opt => opt.MapFrom(dto => dto.SubTemplates));
        profile.CreateMap<Sub_Template, SubTemplateGetDto>();
    }

}