using AutoMapper;
using Roadmap.Application.Common.Mappings;

namespace Roadmap.Application.Funcs.Query.GetSubTemplate;

public class GetSubTemplateOutput : ImapWith<Domain.Sub_Template>
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<Domain.Sub_Template, GetSubTemplateOutput>()
            .ForMember(vm => vm.Id,
                opt => opt.MapFrom(src => src.Id))
            .ForMember(vm => vm.Title,
                opt => opt.MapFrom(src => src.Title))
            .ForMember(vm => vm.Description,
                opt => opt.MapFrom(src => src.Description));
    }
    
}