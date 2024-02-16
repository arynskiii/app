using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Roadmap.Application.Funcs.Commands.Template;
using Roadmap.Application.Funcs.Commands.TemplateUser.CreateTemplateUser;
using Roadmap.Application.Funcs.Query.GetTemplate;
using Roadmap.Domain;
using Roadmap.WebApi.Models;

namespace Roadmap.WebApi.Controllers;



[Route("api/[controller]")]
[ApiController]
public class TemplateController : BaseController
{

    private readonly IMapper _mapper;
    public TemplateController(IMapper mapper) => _mapper = mapper;
    /// <summary>
    /// Create the Template
    /// </summary>
    /// <remarks>
    /// Sample request:
    /// POST /template
    /// {
    ///     title: "template title",
    ///     description: "template description"
    /// }
    /// </remarks>
    /// <param name="id"></param>
    /// <param name="createTemplateDto">createRoadmapDTO object</param>
    /// <returns>Returns id (guid)</returns>
    /// <response code="201"> Success</response>
    /// <response code="401"> If the user is not admin</response>
    [HttpPost()]

    public async Task<ActionResult<Guid>> CreateRoadmap([FromBody] CreateTemplateDTO createTemplateDto)
    {
        var command = _mapper.Map<CreateTemplateCommand>(createTemplateDto);
        var id = await Mediator.Send(command);
        return id;
    }

    
    /// <summary>
    /// Deletes the Template by id
    /// </summary>
    /// <remarks>
    /// Sample request:
    /// DELETE /template/88DEB432-062F-43DE-8DCD-8B6EF79073D3
    /// </remarks>
    /// <param name="id">Id of the template (guid)</param>
    /// <returns>Returns NoContent</returns>
    /// <response code="204">Success</response>
    /// <response code="401">If the user is no admin</response>
    [HttpDelete]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> DeleteTemplate([FromBody] DeleteTemplateDTO deleteTemplateDto)
    {
      await Mediator.Send(deleteTemplateDto);
      return NoContent();

    }
    
    
    /// <summary>
    ///  Gets the Templates
    /// </summary>
    /// <remarks>
    /// Sample request:
    /// POST /template/88DEB432-062F-43DE-8DCD-8B6EF79073D3
    ///</remarks>
    /// <returns>Returns RoadmapVM</returns>
    /// <response code="200"> Success</response>
    /// <response code="404"> If roadmap not found</response>
  [HttpGet("{id}")]
  [Authorize]
  public async Task<ActionResult<GetTemplateOutput>> GetTemplateById(Guid id)
  {
      var command = new GetTemplateCommand
      {
          Id = id
      };
      var templateVM = await Mediator.Send(command);
      return templateVM;
  }


}