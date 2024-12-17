using DefendersDeck.Domain.Responses;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Security.Claims;

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

        protected int RetrieveUserId()
        {
            var userId = User?.Claims?.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;

            if (userId is null)
            {
                return 0;
            }

            return int.Parse(userId);
        }
    }
}
