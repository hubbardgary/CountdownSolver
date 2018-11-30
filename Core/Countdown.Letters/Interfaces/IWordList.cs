using System.Collections.Generic;

namespace Countdown.Core.Letters.Interfaces
{
    public interface IWordList
    {
        IEnumerable<string> Words();
    }
}
