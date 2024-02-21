using AutoMapper;
using Roadmap.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Roadmap.Application.DTOs;

namespace Roadmap.Application.Funcs.Query.GetAllCategories;

public class CategoryListHandler : IRequestHandler<CategoryListQuery,CategoryListVM>
{
    private readonly IAppDbContext _DbContext;
    private readonly IMapper _mapper;

    public CategoryListHandler(IAppDbContext dbContext, IMapper mapper) =>
        (_DbContext, _mapper) = (dbContext, mapper);

    public async Task<CategoryListVM> Handle(CategoryListQuery request, CancellationToken cancellationToken)
    {
   var categories=   await  _DbContext.Categories.ToListAsync(cancellationToken);
   var categoriesVm = _mapper.Map<List<CategoryVMDTO>>(categories);
   return new CategoryListVM()
   {
       Categories = categoriesVm
   };
    }

}
