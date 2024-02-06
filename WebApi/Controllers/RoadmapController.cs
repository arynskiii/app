using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Roadmap.Application.Roadmaps.Commands.CreateRoadmap;
using Roadmap.Application.Roadmaps.Query;
using Roadmap.WebApi.Models;

namespace Roadmap.WebApi.Controllers;


[Route("api/[controller]")]
public class RoadmapController : BaseController
{
    private readonly IMapper _mapper;

    public RoadmapController(IMapper mapper) =>
        _mapper = mapper;

    [HttpGet]
    public async Task<ActionResult<RoadmapVM>> GetAllRoadmaps()
    {
        var query = new GetRoadmapListQuery()
        {
            UserId = UserId
        };
        
        var vm = await Mediator.Send(query);
        return Ok(vm);
    }

    [HttpPost]
    public async Task<ActionResult<Guid>> CreateRoadmap([FromBody] CreateRoadmapDTO createRoadmapDto)
    {
        var command = _mapper.Map<CreateRoadmapCommand>(createRoadmapDto);
        var id = await Mediator.Send(command);
        return id;
    }
    
}