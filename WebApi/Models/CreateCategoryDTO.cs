using AutoMapper;
using Roadmap.Application.Common.Mappings;
using Roadmap.Application.Funcs.Commands.Category.CreateCategory;

namespace Roadmap.WebApi.Models;

public class CreateCategoryDTO: ImapWith<CreateCategoryCommand>
{
    
    public string Title { get; set; }
    public string Description { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<CreateCategoryDTO, CreateCategoryCommand>()
            .ForMember(categoryCommand => categoryCommand.Description,
                opt => opt.MapFrom(categoryDTO => categoryDTO.Description))
            .ForMember(categoryCommand => categoryCommand.Title,
                opt => opt.MapFrom(categoryDTO => categoryDTO.Title));
    }
    
}