using Countdown.Core.Dtos;

namespace Countdown.Api.Services.Interfaces
{
    public interface INumbersService
    {
        NumbersSolutionDto GetSolutions(int target, int[] numbers);
    }
}
