using Microsoft.AspNetCore.Mvc;
using Wiring.Data;
using Wiring.Services;

namespace Wiring.Server.Controllers
{
    [ApiController]
    [Route("api/v1/Wiring/")]
    public class WiringController : ControllerBase
    {
        private readonly IShassiService _shassiService;

        public WiringController(IShassiService shassiService)
        {
            _shassiService = shassiService;
        }

        [HttpGet("generate-shassi")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IEnumerable<ShassiResponse>>> GenerateAndValidateShassi()
        {
            try
            {
                var response = await _shassiService.GenerateAndValidateShassi();
                return Ok(response);
            }
            catch
            {
                return BadRequest($"Failed to generate sasshi");
            }
        }
    }
}