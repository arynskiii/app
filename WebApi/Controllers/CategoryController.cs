using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Roadmap.Application.Funcs.Commands.Category.CreateCategory;
using Roadmap.WebApi.Models;

namespace Roadmap.WebApi.Controllers;


[Route("api/[controller]/[action]")]
[ApiController]
public class CategoryController : BaseController
{
    private readonly IMapper _mapper;
    public CategoryController(IMapper mapper) => _mapper = mapper;

    [HttpPost]
    public async Task<ActionResult<Guid>> CreateCategory([FromBody] CreateCategoryDTO createCategoryDTO)
    {
       var command= _mapper.Map<CreateCategoryCommand>(createCategoryDTO);
      var id= await Mediator.Send(command);
      return id;
    }

}