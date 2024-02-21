using AutoMapper;
using MediatR;
using Roadmap.Application.Interfaces;

namespace Roadmap.Application.Funcs.Query.GetSubTemplate;

public class GetSubTemplateHandler : IRequestHandler<GetSubTemplateCommand,GetSubTemplateOutput>
{
    private readonly IAppDbContext _DbContext;
    private readonly IMapper _mapper;

    public GetSubTemplateHandler(IAppDbContext dbContext, IMapper mapper) =>
        (_DbContext, _mapper) = (dbContext, mapper);


    public async Task<GetSubTemplateOutput> Handle(GetSubTemplateCommand request, CancellationToken cancellationToken)
    {
      var subTemplate=  await _DbContext.SubStages.FindAsync(request.Id);
      if (subTemplate == null)
      {
          throw new Exception("Cannot found subTemplate by this ID");
      }

      var subTemplateVM = _mapper.Map<GetSubTemplateOutput>(subTemplate);
      return subTemplateVM;
    }

    
}