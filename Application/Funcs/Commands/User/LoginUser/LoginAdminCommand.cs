using MediatR;

namespace Roadmap.Application.Roadmaps.Commands.Admin.LoginAdmin;

public class LoginAdminCommand : IRequest <LoginAdminCommandOutput>
{
    public string Email { get; set; }
    public string Password { get; set; }
    
}