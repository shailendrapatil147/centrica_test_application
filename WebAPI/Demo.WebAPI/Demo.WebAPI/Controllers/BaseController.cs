using Demo.WebAPI.Common.Extensions;
using Demo.WebAPI.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Demo.WebAPI.Controllers
{
    public class BaseController : ControllerBase
    {
        protected IDomainFactory _domainFactory { get; set; }
        protected Common.Services.ILogger _logger { get; set; }
        public BaseController(Common.Services.ILogger logger, IDomainFactory domainFactory) 
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _domainFactory = domainFactory.ThrowIfArgumentNull(nameof(domainFactory)); 
        }
    }
}
