using MediatR;

namespace Roadmap.Application.Roadmaps.Commands.CreateAdmin;

public class CreateAdminCommand : IRequest<Guid>
{
    public string Email { get; set; }
    public string Password { get; set; }
    
}