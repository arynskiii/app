using MediatR;

namespace Roadmap.Application.Roadmaps.Commands.CreateEmploye;

public class CreateEmployeCommand : IRequest<string>
{
    public string Email { get; set; }
    public string Password { get; set; }
    public string Position { get; set; }

}