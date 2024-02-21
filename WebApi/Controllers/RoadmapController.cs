using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Roadmap.Application.Funcs.Commands.RoadmapUser.CreateRoadmapUser;
using Roadmap.Application.Funcs.Query.GetRoadmapByID;
using Roadmap.Application.Roadmaps.Commands.CreateRoadmap;
using Roadmap.Application.Roadmaps.Commands.DeleteRoadmap;
using Roadmap.Application.Roadmaps.Commands.UpdateRoadmap;
using Roadmap.Application.Roadmaps.Query;
using Roadmap.WebApi.Models;

namespace Roadmap.WebApi.Controllers;

[ApiController]
[Route("api/[controller]/[action]")]
public class RoadmapController : BaseController
{
    private readonly IMapper _mapper;
    public RoadmapController(IMapper mapper) => _mapper = mapper;
    /// <summary>
    ///  Gets the list of Roadmaps
    /// </summary>
    /// <remarks>
    /// Sample request:</remarks>
    /// <returns>Returns RoadmapListVM</returns>
    /// <response code="200"> Success</response>
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<RoadmapVMDTO>> GetAllRoadmaps()
    {
        var query = new GetRoadmapListQuery();


        var vm = await Mediator.Send(query);
        return Ok(vm);
    }

    /// <summary>
    /// Create the Roadmap
    /// </summary>
    /// <remarks>
    /// Sample request:
    /// POST /roadmap
    /// {
    ///     title: "roadmap title",
    ///     description: "roadmap description"
    /// }
    /// </remarks>
    /// <param name="id"></param>
    /// <param name="createRoadmapDTO">CreateRoadmapDTO object</param>
    /// <returns>Returns id (guid)</returns>
    /// <response code="201"> Success</response>
    /// <response code="401"> If the user is not admin</response>
    [Authorize(Roles = "Admin")]
    [HttpPost("{id}")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public async Task<ActionResult<Guid>> Create(Guid id, [FromBody] CreateRoadmapDTO createRoadmapDTO)
    {
        var command = _mapper.Map<CreateRoadmapCommand>(createRoadmapDTO);
        command.CategoryId = id;

        var i = await Mediator.Send(command);
        return i;
    }

    /// <summary>
    ///  Update the Roadmap
    /// </summary>
    /// <remarks>
    /// Sample request:
    ///PUT /roadmap
    /// {
    ///     title: "roadmap title",
    ///     description: "roadmap description"
    /// }
    /// </remarks>
    /// <param name="updateRoadmapDTO">UpdateRoadmapDTO object</param>
    /// <returns>Returns id (guid)</returns>
    /// <response code="201"> Success</response>
    /// <response code="401"> If the user is not admin</response>
    [Authorize(AuthenticationSchemes = "Bearer")]
    [Authorize(Roles = "Admin")]
    [HttpPut("{id}")]
    public async Task<ActionResult<Guid>> Update(Guid id, [FromBody] UpdateRoadmapDTO updateRoadmapDTO)
    {
        var command = _mapper.Map<UpdateRoadmapCommand>(updateRoadmapDTO);
        command.Id = id;
        var idRoadmap = await Mediator.Send(command);
        return idRoadmap;
    }

    /// <summary>
    /// Deletes the Roadmap by id
    /// </summary>
    /// <remarks>
    /// Sample request:
    /// DELETE /roadmap/88DEB432-062F-43DE-8DCD-8B6EF79073D3
    /// </remarks>
    /// <param name="id">Id of the roadmap (guid)</param>
    /// <returns>Returns NoContent</returns>
    /// <response code="204">Success</response>
    /// <response code="401">If the user is no admin</response>
    [HttpDelete("{id}")]
    [Authorize(Roles = "Admin")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public async Task<IActionResult> Delete(Guid id)
    {
        var command = new DeleteRoadmapCommand { Id = id };
        await Mediator.Send(command);
        return NoContent();
    }

    /// <summary>
    ///  Gets the Roadmap
    /// </summary>
    /// <remarks>
    /// Sample request:
    /// POST /roadmap/getRoadmapByID/88DEB432-062F-43DE-8DCD-8B6EF79073D3
    ///</remarks>
    /// <returns>Returns RoadmapVM</returns>
    /// <response code="200"> Success</response>
    /// <response code="404"> If roadmap not found</response>
    [Authorize]
    [HttpPut("{id}")]
    public async Task<ActionResult<RoadmapVMDTO>> Get(Guid id)
    {
        var command = new GetRoadmapByIDQuery { Id = id };


        var secCommand = new CreateRoadmapUserCommand
        {
            RoadmapId = command.Id
        };
        secCommand.UserId = UserId;
        await Mediator.Send(secCommand);

        var roadmapVM = await Mediator.Send(command);
        return roadmapVM;
    }
}