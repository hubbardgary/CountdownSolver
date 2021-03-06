﻿using Countdown.Api.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Countdown.Api.Controllers
{
    [Route("api/[controller]")]
    public class LettersController : Controller
    {
        private readonly ILettersService _lettersService;

        public LettersController(ILettersService lettersService)
        {
            _lettersService = lettersService;
        }

        // GET api/letters/solve?letters=a&letters=b&letters=e&letters=p&letters=s&letters=f&letters=u&letters=b&letters=s
        [Route("solve")]
        public ActionResult Solve([FromQuery] char[] letters)
        {
            if (letters.Length != 9)
            {
                return BadRequest("letters must have a length of 9");
            }

            return Ok(_lettersService.GetSolutions(letters));
        }
    }
}
