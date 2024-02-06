using MediatR;

namespace Roadmap.Application.Roadmaps.Commands.CreateAdmin;

public class CreateUserCommand : IRequest<Guid>
{
    public string Email { get; set; }
    public string Password { get; set; }
    
}