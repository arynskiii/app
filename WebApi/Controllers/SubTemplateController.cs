using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Roadmap.Application.Funcs.Commands.Sub_Template.CreateSub_Template;
using Roadmap.Application.Funcs.Commands.SubTemplateUser.CreateSubTemplateUser;
using Roadmap.Application.Funcs.Query.GetSubTemplate;
using Roadmap.WebApi.Models;

namespace Roadmap.WebApi.Controllers;
[Route("api/[controller]")]
[ApiController]

public class SubTemplateController : BaseController
{
    private readonly IMapper _mapper;

    public SubTemplateController(IMapper mapper) => _mapper = mapper;
    
    /// <summary>
    /// Create the subTemplate
    /// </summary>
    /// <remarks>
    /// Sample request:
    /// POST /SubTemplate
    /// {
    ///     title: "subTemplate title",
    ///     description: "subTempalte description"
    /// }
    /// </remarks>
    /// <param name="id"></param>
    /// <param name="subTemplateDto>CreateSubTemplateDTO object"</param>
    /// <returns>Returns id (guid)</returns>
    /// <response code="201"> Success</response>
    /// <response code="401"> If the user is not admin</response>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public async Task<ActionResult<Guid>> CreateSubTemplate([FromBody] CreateSubTemplateDTO subTemplateDto)
    {
        var command = _mapper.Map<CreateSub_TemplateCommand>(subTemplateDto);
        var id = await Mediator.Send(command);
        return id;
    }

    /// <summary>
    /// Gets the subTemplate
    /// </summary>
    /// <remarks>
    /// Sample request:
    /// GET /subtemplate/88DEB432-062F-43DE-8DCD-8B6EF79073D3
    ///</remarks>
    /// <returns>Returns SubTemplateVM</returns>
    /// <response code="200">Success</response>
    /// <response code="404">If subTemplate not found</response>
    [HttpGet("{id}")]
    [Authorize]
    public async Task<GetSubTemplateOutput> GetSubTemplateById(Guid id)
    {
        var command = new GetSubTemplateCommand { Id = id };
        var cm = new CreateSubTemplateUserCommand
        {
            UserId = UserId,
            SubTemplateId = id,
        };
        await Mediator.Send(cm);
        var roadmapVM = await Mediator.Send(command);
        return roadmapVM;
    }

}