using Microsoft.AspNetCore.Mvc;

namespace Sipru.Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HealthController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            return Ok("SIPRU Backend is running");
        }
    }
}
