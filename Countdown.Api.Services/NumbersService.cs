using Countdown.Api.Services.Interfaces;
using Countdown.Api.Services.Models;
using Countdown.Numbers.Interfaces;

namespace Countdown.Api.Services
{
    public class NumbersService : INumbersService
    {
        private readonly INumbersSolver _numbersSolver;

        public NumbersService(INumbersSolver numbersSolver)
        {
            _numbersSolver = numbersSolver;
        }

        public NumbersSolutionDto GetSolutions(int target, int[] numbers)
        {
            return _numbersSolver.Solve(target, numbers);
        }
    }
}
