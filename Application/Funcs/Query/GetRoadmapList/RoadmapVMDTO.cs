using AutoMapper;
using Roadmap.Application.Common.Mappings;
using Roadmap.Application.Dtos.Template;
using Roadmap.Domain;

namespace Roadmap.Application.Roadmaps.Query;

public class RoadmapVMDTO : ImapWith<Domain.Roadmap>
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public List<TemplateGetDTO> Templates { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<Domain.Roadmap, RoadmapVMDTO>()
            .ForMember(rdpmVM => rdpmVM.Title, opt => opt.MapFrom(rdmp => rdmp.Title))
            .ForMember(rdpmVM => rdpmVM.Description, opt => opt.MapFrom(rdmp => rdmp.Description))
            .ForMember(rdpmVM => rdpmVM.Id, opt => opt.MapFrom(rdmp => rdmp.Id))
            .ForMember(rdpmVM => rdpmVM.Templates,
                opt => opt.MapFrom(src => src.Templates));

        profile.CreateMap<Stage, TemplateGetDTO>();
    }
}