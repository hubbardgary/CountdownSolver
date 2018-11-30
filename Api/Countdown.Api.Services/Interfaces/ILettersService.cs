using System.Collections.Generic;

namespace Countdown.Api.Services.Interfaces
{
    public interface ILettersService
    {
        IDictionary<int, List<string>> GetSolutions(char[] letters);
    }
}
