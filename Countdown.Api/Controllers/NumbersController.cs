using Countdown.Api.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Countdown.Api.Controllers
{
    [Route("api/[controller]")]
    public class NumbersController : Controller
    {
        private readonly INumbersService _numbersService;

        public NumbersController(INumbersService numbersService)
        {
            _numbersService = numbersService;
        }

        // GET api/numbers/solve/{target}?nums=n1&nums=n2&nums=n3&nums=n4&nums=n5&nums=n6
        [Route("solve/{target}")]
        public ActionResult Solve(int target, [FromQuery] int[] nums)
        {
            if (target < 100 || target > 999)
            {
                return BadRequest("target must be between 100 and 999 inclusive");
            }

            if (nums.Length != 6)
            {
                return BadRequest("nums must have a length of 6");
            }

            return Ok(_numbersService.GetSolutions(target, nums));
        }
    }
}
