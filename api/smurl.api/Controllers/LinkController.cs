using Microsoft.AspNetCore.Mvc;
using smurl.domain.Models;
using smurl.services.Interfaces;
using System;
using System.Threading.Tasks;

namespace smurl.api.Controllers
{
    [ApiController]
    [Route("_api/link")]
    [Produces("application/json")]
    public class LinkController : ControllerBase
    {
        private readonly ILinkService _linkService;

        public LinkController(ILinkService linkService)
        {
            _linkService = linkService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync(string slug)
        {
            try
            {
                var link = await _linkService.GetLinkAsync(slug);
                return Ok(link);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync(LinkModel model)
        {
            try
            {
                var link = await _linkService.CreateLinkAsync(model);
                return Ok(link);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}