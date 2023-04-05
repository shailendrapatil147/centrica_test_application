using Demo.WebAPI.Contracts.Entites;
using Demo.WebAPI.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Demo.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CityController : BaseController
    {
        public CityController(Common.Services.ILogger logger, IDomainFactory domainFactory) : base(logger, domainFactory)
        {
        }

        [HttpGet]
        [Route("getallcityasync")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<City>))]
        [ProducesResponseType(StatusCodes.Status200OK, Type = null)]
        public async Task<IActionResult> GetAllCityAsync()
        {
            try
            {
                _logger.LogInfo("GetAllCityAsync()");
                return Ok(await _domainFactory.CityDomain.GetAllCityAsync());
            }
            catch (Exception ex)
            {
                _logger.LogError(ex);
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }
    }
}
