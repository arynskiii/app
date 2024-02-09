using System.Net;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Minio;
using Minio.DataModel.Args;
using Minio.Exceptions;
using Roadmap.Application.Funcs.Query.GetRoadmapByID;
using Roadmap.Application.Roadmaps.Commands.CreateRoadmap;
using Roadmap.Application.Roadmaps.Commands.DeleteRoadmap;
using Roadmap.Application.Roadmaps.Commands.UpdateRoadmap;
using Roadmap.Application.Roadmaps.Query;
using Roadmap.WebApi.Models;

namespace Roadmap.WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
[Produces("application/json")]
public class RoadmapController : BaseController



{
    
    private readonly IMinioClient _minioClient;
    private readonly IMapper _mapper;
    public RoadmapController(IMapper mapper, IMinioClient minioClient) =>
        (this._minioClient, this._mapper) = (minioClient, mapper);

    /// <summary>
    ///  Gets the list of Roadmaps
    /// </summary>
    /// <remarks>
    /// Sample request:</remarks>
    /// <returns>Returns RoadmapListVM</returns>
    /// <response code="200"> Success</response>
    /// <response code="401"> If the user is unathorized</response>
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<RoadmapVM>> GetAllRoadmaps()
    {
        var query = new GetRoadmapListQuery()
        {
            UserId = UserId
        };
        
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
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public async Task<ActionResult<Guid>> CreateRoadmap( [FromQuery] CreateRoadmapDTO createRoadmapDTO)
    {
        
        try
        {
            if (createRoadmapDTO == null)
            {
                return BadRequest("CreateRoadmapCommand object is null.");
            }

            if (createRoadmapDTO.File == null)
            {
                return BadRequest("File is not provided.");
            }

            // var beArgs = new BucketExistsArgs()
            //     .WithBucket("test");
            //
            // bool found = await _minioClient.BucketExistsAsync(beArgs).ConfigureAwait(false);
            //
            // if (!found)
            // {
            //     var mbArgs = new MakeBucketArgs()
            //         .WithBucket("test");
            //     await _minioClient.MakeBucketAsync(mbArgs).ConfigureAwait(false);
            // }
            var putObjectArgs = new PutObjectArgs()
                .WithBucket("mybucket")
                .WithObject(createRoadmapDTO.File.FileName)
                .WithFileName(createRoadmapDTO.File.FileName);
            await _minioClient.PutObjectAsync(putObjectArgs).ConfigureAwait(true);
        }
        catch (MinioException e)
        {
            Console.WriteLine("File Upload Error: {0}", e.Message);
            return StatusCode(500, "Internal server error.");
        }
        var command = _mapper.Map<CreateRoadmapCommand>(createRoadmapDTO);
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
    [HttpPut]
    public async Task<ActionResult<Guid>> Update([FromBody] UpdateRoadmapDTO updateRoadmapDTO)
    {
        var command = _mapper.Map<UpdateRoadmapCommand>(updateRoadmapDTO);
        var id=  await Mediator.Send(command);
      return id;
    }
    
    /// <summary>
    /// Deletes the Roadmap by id
    /// </summary>
    /// <remarks>
    /// Sample request:
    /// DELETE /roadmap/88DEB432-062F-43DE-8DCD-8B6EF79073D3
    /// </remarks>
    /// <param name="id">Id of the note (guid)</param>
    /// <returns>Returns NoContent</returns>
    /// <response code="204">Success</response>
    /// <response code="401">If the user is no admin</response>
    [HttpDelete]
    [Authorize(Roles = "Admin")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]   
    public async Task<IActionResult> Delete([FromBody]DeleteRoadmapDTO deleteRoadmapDto)
    {
        var sId = _mapper.Map<DeleteRoadmapCommand>(deleteRoadmapDto);
        
        await Mediator.Send(sId);
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
    [HttpPut("get")]
    public async Task<ActionResult<RoadmapVM>> GetRoadmapByID([FromBody] GetRoadmapByIDDTO getRoadmapByIddto)
    {
        var id = _mapper.Map<GetRoadmapByIDQuery>(getRoadmapByIddto);
        var roadmapVM = await Mediator.Send(id);
        return roadmapVM;
    }
        
    
}