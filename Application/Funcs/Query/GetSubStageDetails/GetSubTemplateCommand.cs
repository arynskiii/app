using MediatR;

namespace Roadmap.Application.Funcs.Query.GetSubTemplate;

public class GetSubTemplateCommand : IRequest<GetSubTemplateOutput>
{
    public Guid Id { get; set; }
    
}