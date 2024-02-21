using AutoMapper;
using Roadmap.Application.Common.Mappings;
using Roadmap.Domain;

namespace Roadmap.Application.DTOs;

public class CategoryVMDTO : ImapWith<Category>
{
    public string Title { get; set; }
    public string Description { get; set; }
    public List<Domain.Roadmap> Roadmaps { get; set; }
    
   

    public void Mapping(Profile profile)
    {
        profile.CreateMap<Category, CategoryVMDTO>()
            .ForMember(com => com.Description,
                opt => opt.MapFrom(dto => dto.Description))
            .ForMember(com => com.Title,
                opt => opt.MapFrom(dto => dto.Title));

        profile.CreateMap<Domain.Roadmap, Domain.Roadmap>();
    }
}