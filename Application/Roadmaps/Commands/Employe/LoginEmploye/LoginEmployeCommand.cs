using MediatR;

namespace Roadmap.Application.Roadmaps.Commands.Employe.LoginEmploye;

public class LoginEmployeCommand : IRequest<LoginEmployeCommandOutput>
{
    public string Email { get; set; }
    public string Password { get; set; }

}