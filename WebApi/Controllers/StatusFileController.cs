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
public class StatusFileController : BaseController
{
    private readonly IMapper _mapper;
    public StatusFileController(IMapper mapper) => _mapper = mapper;

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
    public async Task<Guid> VerifyTaskStatus([FromForm] StatusSubTemplateDTO statusSubTemplateDto)
    {
        var minio = new MinioClient()
            .WithEndpoint("localhost:9000")
            .WithCredentials("uhXXMORdeqf5nppJ", "AGwBcU7N9UkS0WzGp32cQIeFQfmGQ43S")
            .WithSSL(false)
            .Build();
        
        var command = _mapper.Map<CreateStatusFileCommand>(statusSubTemplateDto);
        command.UserId = UserId;
        try
        {
            var beArgs = new BucketExistsArgs().WithBucket("mybucket");
            bool found = await minio.BucketExistsAsync(beArgs).ConfigureAwait(false);
            if (!found)
            {
                var mbArgs = new MakeBucketArgs()
                    .WithBucket("mybucket");
                await minio.MakeBucketAsync(mbArgs).ConfigureAwait(false);
            }

            var putObjectArgs = new PutObjectArgs()
                .WithBucket("mybucket")
                .WithObject(command.File.FileName)
                .WithContentType(command.File.ContentType)
                .WithStreamData(command.File.OpenReadStream())
                .WithObjectSize(command.File.Length);
            
            await minio.PutObjectAsync(putObjectArgs).ConfigureAwait(false);
            
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
        var resId = await Mediator.Send(command);
        return resId;
    }

}