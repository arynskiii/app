using System.Security.Claims;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Roadmap.Application.Roadmaps.Commands.Admin.LoginAdmin;
using Roadmap.Application.Roadmaps.Commands.CreateAdmin;
using Roadmap.WebApi.Models;

namespace Roadmap.WebApi.Controllers; 
public class UserController : BaseController
{

    private readonly IMapper _mapper;
    public UserController(IMapper mapper) => _mapper = mapper;
    /// <summary>
    ///  Create User
    /// </summary>
    /// <remarks>
    /// Sample request:
    ///POST /user
    /// {
    ///     email: "user email",
    ///     password: "user password"
    /// }
    /// </remarks>
    /// <param name="userDTO"> userDTO object</param>
    /// <returns>Returns id (guid)</returns>
    /// <response code="200"> Success</response>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<Guid>> CreateUser([FromBody] CreateUserDTO userDTO)
    {
       var command= _mapper.Map<CreateUserCommand>(userDTO);
      var userId=await Mediator.Send(command);
      return userId;
    }

    
    /// <summary>
    ///  Login User
    /// </summary>
    /// <remarks>
    /// Sample request:
    ///POST /user/login
    /// {
    ///     email: "user email",
    ///     password: "user password"
    /// }
    /// </remarks>
    /// <param name="LoginUserDTO"> userDTO object</param>
    /// <returns></returns>
    /// <response code="200"> Success</response>
    /// <response code="400"> If the user write uncorrect data</response>
    [HttpPost("login")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<ActionResult> Login([FromBody] LoginUserDTO userDto)
    {
        var input = new LoginAdminCommand();
        input.Email = userDto.Email;
        input.Password = userDto.Password;
        try
        {
          var otput=await  Mediator.Send(input);
          return Ok(otput);
        }
        catch (Exception exception)
        {
            return Unauthorized(exception.Message);
        }

    }
    
}