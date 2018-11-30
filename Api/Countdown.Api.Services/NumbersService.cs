using Countdown.Api.Services.Interfaces;
using Countdown.Core.Dtos;
using Countdown.Core.Numbers.Interfaces;

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
