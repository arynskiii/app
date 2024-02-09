using System.Security.Claims;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Minio;

namespace Roadmap.WebApi.Controllers
{
    [ApiVersion("1.0")]
    [ApiVersion("2.0")]
    [Produces("application/json")]
    [ApiController]
    [Route("api/{version:apiVersion}/[controller]")]
    public class BaseController : ControllerBase
    {
        private IMediator _mediator;
        private IMinioClient _minioClient;
        
        protected IMinioClient MinioClient => _minioClient ??= HttpContext.RequestServices.GetService<IMinioClient>();

        protected IMediator Mediator => _mediator ??= HttpContext.RequestServices.GetService<IMediator>();

      

        internal Guid UserId => !User.Identity.IsAuthenticated
            ? Guid.Empty
            : Guid.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);
    }
}