using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Roadmap.Application.Funcs.Commands.Template;
using Roadmap.Application.Funcs.Commands.TemplateUser.CreateTemplateUser;
using Roadmap.WebApi.Models;

namespace Roadmap.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TemplateUserController : BaseController
{
    private readonly IMapper _mapper;
    public TemplateUserController(IMapper mapper) => _mapper = mapper;

    
    /// <summary>
    /// Create the TemplateUser
    /// </summary>
    /// <remarks>
    /// Sample request:
    /// POST /templateuser
    /// </remarks>
    /// <param name="id"></param>
    /// <param name="chooseTemplateDto">Choose Template DTO object</param>
    /// <returns>Returns id (guid)</returns>
    /// <response code="201"> Success</response>
    /// <response code="401"> If the user is not admin</response>
    [Authorize]
    [HttpPost]
    public async Task<ActionResult<Guid>> ChooseTemplate([FromBody] ChooseTemplateDTO chooseTemplateDto)
    {
      var command=  _mapper.Map<CreateTemplateUserCommand>(chooseTemplateDto);
      command.RoadmapUser.UserId = UserId;
      var id = await Mediator.Send(command);
      return id;
    }
}