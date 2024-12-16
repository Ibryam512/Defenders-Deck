using DefendersDeck.Domain.Responses;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace DefendersDeck.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseController : ControllerBase
    {
        protected IActionResult HandleFailure<T>(BaseResponse<T> response)
        {
            return response.StatusCode switch
            {
                HttpStatusCode.BadRequest => BadRequest(response),
                HttpStatusCode.NotFound => NotFound(response),
                _ => StatusCode((int)response.StatusCode, response),
            };
        }
    }
}
