using AutoMapper;
using Roadmap.Application.Common.Mappings;
using Roadmap.Application.Roadmaps.Commands.CreateAdmin;

namespace Roadmap.WebApi.Models;

public class CreateUserDTO : ImapWith<CreateUserCommand>
{
    public string Email { get; set; }
    public string Password { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<CreateUserDTO, CreateUserCommand>()
            .ForMember(com => com.Email,
                opt => opt.MapFrom(dto => dto.Email))
            .ForMember(com => com.Password,
                opt => opt.MapFrom(dto => dto.Password)); 
    }
}