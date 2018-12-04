using Microsoft.AspNetCore.Mvc;

namespace Countdown.Api.Controllers
{
    [Route("api/[controller]")]
    public class HealthCheckController : Controller
    {
        // GET api/healthcheck/heartbeat
        [Route("heartbeat")]
        public ActionResult Heartbeat()
        {
            return Ok("alive");
        }
    }
}
