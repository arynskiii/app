using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Roadmap.Application.DTOs;
using Roadmap.Application.Funcs.Commands.Category.CreateCategory;
using Roadmap.Application.Funcs.Query.GetAllCategories;
using Roadmap.WebApi.Models;

namespace Roadmap.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CategoryController : BaseController
{
    private readonly IMapper _mapper;
    public CategoryController(IMapper mapper) => _mapper = mapper;

    [HttpPost]
    [Authorize(Roles = "Admin")]
    public async Task<ActionResult<Guid>> Category([FromBody] CreateCategoryDTO createCategoryDTO)
    {
        var command = _mapper.Map<CreateCategoryCommand>(createCategoryDTO);
        var id = await Mediator.Send(command);
        return id;
    }


    [HttpGet]
    public async Task<ActionResult<CategoryVMDTO>> Category()
    {
        var query = new CategoryListQuery();
        var vm = await Mediator.Send(query);
        return Ok(vm);
    }
}