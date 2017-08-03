using Countdown.Api.Services.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Countdown.Numbers.Interfaces
{
    public interface INumbersSolver
    {
        NumbersSolutionDto Solve(int target, int[] numbers);
    }
}
