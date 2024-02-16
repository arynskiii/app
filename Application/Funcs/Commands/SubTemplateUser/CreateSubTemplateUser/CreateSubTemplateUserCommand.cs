using MediatR;

namespace Roadmap.Application.Funcs.Commands.SubTemplateUser.CreateSubTemplateUser;

public class CreateSubTemplateUserCommand : IRequest<Guid>
{
    public Guid SubTemplateId { get; set; }
    public Guid UserId { get; set; }
    public Boolean Flag { get; set; }
}