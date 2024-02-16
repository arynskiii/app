using AutoMapper;
using MediatR;
using Roadmap.Application.Common.Mappings;
using Roadmap.Domain;

namespace Roadmap.Application.Funcs.Query.GetTemplate;

public class GetTemplateCommand : IRequest<GetTemplateOutput>
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    
}