using Angular.ASP_SearchPosition.Data.Entities;
using Angular.ASP_SearchPosition.Services;
using Microsoft.AspNetCore.Mvc;

namespace Angular.ASP_SearchPosition.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LogController : Controller
    {
        private readonly IDbLoggerService _logger;

        public LogController(IDbLoggerService logger)
        {
            _logger = logger;
        }

        // GET: api/log
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RequestModel>>> GetLog()
        {
            return Ok(await _logger.GetLogAsync());
        }
    }
}
