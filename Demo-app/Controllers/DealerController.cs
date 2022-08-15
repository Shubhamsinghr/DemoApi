using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NSwag.Annotations;
using Services.DTO;
using Services.Infrastructure;
using System.Net;

namespace Demo_app.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DealerController : BaseApiController
    {
        private readonly IDealerService _dealerService;

        public DealerController(IDealerService dealerService)
        {
            _dealerService = dealerService;
        }

        [HttpGet]
        [OpenApiOperation("Request an access token.", "")]
        public async Task<IActionResult> GetToken()
        {
            return Ok(await _dealerService.GetToken());
        }

        [HttpPost]
        [OpenApiOperation("Request to get Dealers with search parameter.", "")]
        public async Task<IActionResult> GetDealer([FromBody] DealerModelDTO request)
        {
            if (ModelState.IsValid)
            {
                return Ok(await _dealerService.GetDealers(request));
            }
            else
            {
                return Ok(HttpStatusCode.BadRequest);
            }
        }
    }
}
