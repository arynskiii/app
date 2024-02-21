using MediatR;

namespace Roadmap.Application.Funcs.Commands.Template.DeleteTemplate;

public class DeleteTemplateCommand : IRequest
{
    public Guid Id { get; set; }
}