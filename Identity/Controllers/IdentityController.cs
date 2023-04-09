using Identity.Dtos;
using Identity.Services;
using Microsoft.AspNetCore.Mvc;

namespace Identity.Controllers
{
    [Route("api/identities")]
    [ApiController]
    public class IdentityController : ControllerBase
    {
        private readonly IIdentityService _identityServices;
        private readonly ILogger<IdentityController> _logger;

        public IdentityController(IIdentityService identityServices, ILogger<IdentityController> logger)
        {
            _identityServices = identityServices;
            _logger = logger;
        }

        /// <summary>
        /// Get identity of the given name
        /// </summary>
        /// <param name="name">Name of the person to identify</param>
        /// <returns>Returns identity of the provided name</returns>
        /// <response code="200">Successfully retrieved the identity having the name</response>
        /// <response code="400">Name is required</response>
        /// <response code="500">Internal server error</response>
        [HttpGet]
        [Produces("application/json")]
        [ProducesResponseType(typeof(IdentityDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetIdentity(string name)
        {
            try
            {
                var response = await _identityServices.GetIdentity(name);
                
                if (name == string.Empty)
                {
                    return StatusCode(400, "Please enter a name");
                }

                return Ok(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occured while getting identity");
                return StatusCode(500, "Something went wrong");
            }
        }
    }
}
