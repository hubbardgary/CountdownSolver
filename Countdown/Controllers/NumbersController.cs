using Countdown.Api.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Countdown.Controllers
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
            if(nums.Length != 6)
            {
                return NotFound("nums must have a length of 6");
            }

            return Json(_numbersService.GetSolutions(target, nums));
        }
    }
}
