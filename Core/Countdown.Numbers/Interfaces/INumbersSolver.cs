using Countdown.Core.Dtos;

namespace Countdown.Core.Numbers.Interfaces
{
    public interface INumbersSolver
    {
        NumbersSolutionDto Solve(int target, int[] numbers);
    }
}
