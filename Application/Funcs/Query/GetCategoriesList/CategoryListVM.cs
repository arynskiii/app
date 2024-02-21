using AutoMapper;
using Roadmap.Application.Common.Mappings;
using Roadmap.Application.DTOs;
using Roadmap.Application.Roadmaps.Query;
using Roadmap.Domain;

namespace Roadmap.Application.Funcs.Query.GetAllCategories;

public class CategoryListVM
{
  public IList<CategoryVMDTO> Categories
  {
    get;
    set;
  }
    
    
    
}