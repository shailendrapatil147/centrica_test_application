using Demo.WebAPI.Contracts.Entites;
using Demo.WebAPI.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Demo.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : BaseController
    {
        public UserController(Common.Services.ILogger logger, IDomainFactory domainFactory) : base(logger, domainFactory)
        {
        }

        [HttpGet]
        [Route("getallusersasync")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<User>))]
        [ProducesResponseType(StatusCodes.Status200OK, Type = null)]
        public async Task<IActionResult> GetAllUsersAsync()
        {
            try
            {
                _logger.LogInfo("GetAllUsersAsync()");
                return Ok(await _domainFactory.UserDomain.GetAllUsersAsync());
            }
            catch (Exception ex)
            {
                _logger.LogError(ex);
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }

        [HttpGet]
        [Route("getallusersbycityidasync")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<UserByCityId>))]
        [ProducesResponseType(StatusCodes.Status200OK, Type = null)]
        public async Task<IActionResult> GetAllUsersByCityIdAsync(int CityId)
        {
            try
            {
                _logger.LogInfo("GetAllUsersByCityIdAsync()");
                return Ok(await _domainFactory.UserDomain.GetAllUsersByCityIdAsync(CityId));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex);
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }

        [HttpGet]
        [Route("getallrolesasync")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<Role>))]
        [ProducesResponseType(StatusCodes.Status200OK, Type = null)]
        public async Task<IActionResult> GetAllRolesAsync()
        {
            try
            {
                return Ok(await _domainFactory.UserDomain.GetAllRolesAsync());
            }
            catch (Exception ex)
            {
                _logger.LogError(ex);
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }

        [HttpPost]
        [Route("adduserasync")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(int))]
        public async Task<IActionResult> AddUserAsync(User user)
        {
            try
            {
                return Ok(await _domainFactory.UserDomain.AddUserAsync(user));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex);
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }

        [HttpPost]
        [Route("adduserroleasync")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(int))]
        public async Task<IActionResult> AddUserRoleAsync(UserRole userRole)
        {
            try
            {
                return Ok(await _domainFactory.UserDomain.AddUserRoleAsync(userRole));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex);
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }
    }
}
