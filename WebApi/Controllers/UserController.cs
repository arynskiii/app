using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Roadmap.Application.Roadmaps.Commands.Admin.LoginAdmin;
using Roadmap.Application.Roadmaps.Commands.CreateAdmin;
using Roadmap.WebApi.Models;

namespace Roadmap.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserController : BaseController
{

    private readonly IMapper _mapper;
    public UserController(IMapper mapper) => _mapper = mapper;

    [HttpPost]
    public async Task<ActionResult<Guid>> CreateAdmin([FromBody] UserDTO userDTO)
    {
        var command = _mapper.Map<CreateUserCommand>(userDTO);
      var id=  await Mediator.Send(command);
      return id;

    }

    [HttpPost("login")]
    public async Task<ActionResult> Login([FromBody] UserDTO userDto)
    {
        var input = new LoginAdminCommand();
        input.Email = userDto.Email;
        input.Password = userDto.Password;
        try
        {
          var otput=  Mediator.Send(input);
          return Ok(otput);
        }
        catch (Exception exception)
        {
            return Unauthorized(exception.Message);
        }

    }
    
}