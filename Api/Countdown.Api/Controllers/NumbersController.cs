using Countdown.Api.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

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
                return BadRequest($"Target must be between 100 and 999 inclusive. This request's target was {target}.");
            }
            if (nums.Any(n => n > 100))
            {
                return BadRequest($"All selected numbers must be between 1 and 100. This request's numbers were {string.Join(", ", nums)}.");
            }

            if (nums.Length != 6)
            {
                return BadRequest($"Request must provide 6 numbers. This request provided {nums.Length}, which were {string.Join(", ", nums)}.");
            }

            return Ok(_numbersService.GetSolutions(target, nums));
        }
    }
}
