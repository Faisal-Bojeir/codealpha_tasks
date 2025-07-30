using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using URL_Shortener.EF.Common;

namespace URL_Shortener.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MyBaseController : ControllerBase
    {
        [NonAction]
        public ObjectResult Result(Result response)
        {
            if (response.IsSuccess)
            {
                if (response.StatudCode == StatusCodes.Status200OK)
                    return Ok(response);
                else
                    return Created(string.Empty, response);
            }
            else
            {
                if (response.StatudCode == StatusCodes.Status404NotFound)
                    return NotFound(response);
                else
                    return UnprocessableEntity(response);
            }
        }
    }
}
