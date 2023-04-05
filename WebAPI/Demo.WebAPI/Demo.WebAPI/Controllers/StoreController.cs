using Demo.WebAPI.Contracts.Entites;
using Demo.WebAPI.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Demo.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StoreController : BaseController
    {
        public StoreController(Common.Services.ILogger logger, IDomainFactory domainFactory) : base(logger, domainFactory)
        {
        }

        [HttpGet]
        [Route("getallstoresbycityidasync")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<StoreByCityId>))]
        [ProducesResponseType(StatusCodes.Status200OK, Type = null)]
        public async Task<IActionResult> GetAllStoresByCityIdAsync(int CityId)
        {
            try
            {
                return Ok(await _domainFactory.StoreDomain.GetAllStoresByCityIdAsync(CityId));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex);
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }

        [HttpPost]
        [Route("addstoreasync")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(int))]
        public async Task<IActionResult> AddStoreAsync(Store Store)
        {
            try
            {
                return Ok(await _domainFactory.StoreDomain.AddStoreAsync(Store));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex);
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }
    }
}
