using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Roadmap.Application.Common.Exceptions;
using Roadmap.Application.Interfaces;

namespace Roadmap.Application.Funcs.Query.GetTemplate;

public class GetTemplateHandler : IRequestHandler<GetTemplateCommand,GetTemplateOutput>
{
    private readonly IAppDbContext _DbContext;
    private readonly IMapper _mapper;

    public GetTemplateHandler(IAppDbContext dbContext, IMapper mapper) =>
        (_DbContext, _mapper) = (dbContext, mapper);

    public async Task<GetTemplateOutput> Handle(GetTemplateCommand request, CancellationToken cancellationToken)
    {
        var template = await _DbContext.Templates.Include(r => r.SubTemplates)
            .FirstOrDefaultAsync(q => q.Id == request.Id, cancellationToken: cancellationToken);
        if (template == null)
        {
            throw new NotFoundException(nameof(template), request.Id);
        }
        
        var TemplateVM = _mapper.Map<GetTemplateOutput>(template);
        return TemplateVM;
    }
}