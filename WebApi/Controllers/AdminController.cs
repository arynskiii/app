using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Roadmap.Application.Roadmaps.Commands.CreateAdmin;
using Roadmap.WebApi.Models;

namespace Roadmap.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AdminController : BaseController
{

    private readonly IMapper _mapper;
    public AdminController(IMapper mapper) => _mapper = mapper;

    [HttpPost]
    public async Task<ActionResult<Guid>> CreateAdmin([FromBody] CreateAdminDTO createAdminDto)
    {
        var command = _mapper.Map<CreateAdminCommand>(createAdminDto);
      var id=  await Mediator.Send(command);
      return id;

    }
}