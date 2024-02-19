using MediatR;
using Microsoft.AspNetCore.Http;

namespace Roadmap.Application.Funcs.Commands.StatusFile;

public class SendFileCommand : IRequest
{
    
    public IFormFile File { get; set; }

}