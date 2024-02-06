using AutoMapper;
using Roadmap.Application.Common.Mappings;

namespace Roadmap.Application.Roadmaps.Query;

public class RoadmapVM : ImapWith<Domain.Roadmap>
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<Domain.Roadmap, RoadmapVM>()
            .ForMember(rdpmVM => rdpmVM.Title, opt => opt.MapFrom(rdmp => rdmp.Title))
            .ForMember(rdpmVM => rdpmVM.Description, opt => opt.MapFrom(rdmp => rdmp.Description))
            .ForMember(rdpmVM => rdpmVM.Id, opt => opt.MapFrom(rdmp => rdmp.Id));
    }
}