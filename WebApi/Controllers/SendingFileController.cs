using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Minio.DataModel.Args;
using Roadmap.Application.Funcs.Commands.StatusFile;
using Roadmap.WebApi.Models;
using Minio;
using Minio.Exceptions;
using Minio.DataModel;
using Minio.Credentials;
using Minio.DataModel.Args;

namespace Roadmap.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class SendingFileController : BaseController
{
    private readonly IMapper _mapper;
    public SendingFileController(IMapper mapper) => _mapper = mapper;

    /// <summary>
    /// Send file and change status
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <param name="id"></param>
    /// <param name="statusSubTemplateDto>statusSubTemplateDto object"</param>
    /// <returns>Returns id (guid)</returns>
    /// <response code="200"> Success</response>
    /// <response code="401"> If the user is not unauthorized</response>
    [HttpPost()]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public async Task SendFile([FromForm] SendFileDTO sendFileDTO)
    {
        var command = _mapper.Map<CreateStatusFileCommand>(sendFileDTO);
        command.UserId = UserId;
        var file = new SendFileCommand()
        {
            File = command.File
        };

         await Mediator.Send(file);
        await Mediator.Send(command);
    }
}