using MediatR;
using Microsoft.AspNetCore.Http;

namespace Roadmap.Application.Funcs.Commands.StatusFile;

public class CreateStatusFileCommand : IRequest<Guid>
{
    public Guid UserId { get; set; }
    public IFormFile File { get; set; }
    public Guid SubTemplateId { get; set; }
}