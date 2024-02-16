using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Roadmap.Application.Funcs.Commands.RoadmapUser.CreateRoadmapUser;
using Roadmap.Application.Funcs.Query.GetRoadmapForUser;
using Roadmap.WebApi.Models;

namespace Roadmap.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class RoadmapUserController : BaseController
{
    private readonly IMapper _mapper;
    public RoadmapUserController(IMapper mapper) => _mapper = mapper;

    /// <summary>
    /// Create the Roadmap
    /// </summary>
    /// <remarks>
    /// Sample request:
    /// POST /roadmapuser
    /// {
    ///     roadmapId: "roadmapId "
    /// }
    /// </remarks>
    /// <param name="id"></param>
    /// <param name="chooseRoadmapDto">chooseRoadmapDto object</param>
    /// <returns>Returns id (guid)</returns>
    /// <response code="201"> Success</response>
    /// <response code="401"> If the user is not admin</response>
   [Authorize]
    [HttpPost("createRoadmapforUse")]
    public async Task<ActionResult<Guid>> ChooseRoadmap([FromBody] ChooseRoadmapDTO chooseRoadmapDto)
    {
        var command = _mapper.Map<CreateRoadmapUserCommand>(chooseRoadmapDto);
       
        command.UserId = UserId;
        var id = await Mediator.Send(command);
        return id;
    }
    //
    // [HttpGet]
    // public async Task<ActionResult<>>
}