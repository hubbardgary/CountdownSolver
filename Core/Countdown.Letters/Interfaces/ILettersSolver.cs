using System.Collections.Generic;

namespace Countdown.Core.Letters.Interfaces
{
    public interface ILettersSolver
    {
        IDictionary<int, List<string>> Solve(char[] letters);
    }
}
