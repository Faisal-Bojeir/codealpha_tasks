using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using URL_Shortener.Core.Const;
using URL_Shortener.EF.Dtos.GetShortLink;
using URL_Shortener.EF.Dtos.NewShortLink;
using URL_Shortener.EF.Interface.Domain;
using URL_Shortener.EF.Interface.Services;

namespace URL_Shortener.Controllers
{
    [Route(ApiRoutes.ShortenerLink.Base)]
    [ApiController]
    public class ShortenerLinksController : MyBaseController
    {
        private readonly IShortenedLinksService _service;
        
        public ShortenerLinksController(IShortenedLinksService service)
        {
            _service = service;
        }

        //For a developer who wants to use this api and get full url info
        [HttpPost(ApiRoutes.ShortenerLink.Create)]
        public async Task<IActionResult> AddNewShortLink([FromBody] NewShortLinkDto dto)
        {
            var result = await _service.AddShortLink(dto);
            return Result(result);
        }

        //For a regular user
        [HttpPost("{code}")]
        public async Task<IActionResult> AddNewShortLink(string code, [FromBody] string originalUrl)
        {
            var result = await _service.AddShortLink(code, originalUrl);
            return Result(result);
        }

        //For a developer who wants to use this api and get full url info
        [HttpGet(ApiRoutes.ShortenerLink.GetByOriginalUrl)]
        public async Task<IActionResult> GetOriginalLinkInfo([FromQuery] GetShortLinkRequestDto dto)
        {
            var result = await _service.GetTheOriginalLinkInfo(dto);
            return Result(result);
        }

        //For a regular user
        [HttpGet("/{code}")]
        public async Task<IActionResult> RedirectTo(string code)
        {
            var result = await _service.GetTheOriginalLink(code);
            if (result is null)
                return NotFound("No shortener code found.");
            return Redirect(result);
        }
    }
}
