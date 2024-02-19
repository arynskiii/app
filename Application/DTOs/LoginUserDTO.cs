using AutoMapper;
using Roadmap.Application.Common.Mappings;
using Roadmap.Application.Roadmaps.Commands.Admin.LoginAdmin;
using Roadmap.Application.Roadmaps.Commands.CreateAdmin;

namespace Roadmap.WebApi.Models;

public class LoginUserDTO : ImapWith<LoginAdminCommand>
{
    public string Email { get; set; }
    public string Password { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<LoginUserDTO, LoginAdminCommand>()
            .ForMember(com => com.Email,
                opt => opt.MapFrom(dto => dto.Email))
            .ForMember(com => com.Password,
                opt => opt.MapFrom(dto => dto.Password)); 
    }
}