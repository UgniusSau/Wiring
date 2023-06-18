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
        public async Task<ActionResult<IEnumerable<Harness>>> GenerateShassi()
        {
            try
            {
                var response = await _shassiService.GenerateShassi();
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest($"Failed to generate sasshi: {ex.Message}");
            }
        }
    }
}