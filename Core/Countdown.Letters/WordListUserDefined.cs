using Countdown.Core.Letters.Interfaces;
using System.Collections.Generic;

namespace Countdown.Core.Letters
{
    public class WordListUserDefined : IWordList
    {
        private readonly IEnumerable<string> _permittedWords;

        public WordListUserDefined(IEnumerable<string> permittedWords)
        {
            _permittedWords = permittedWords;
        }

        public IEnumerable<string> Words()
        {
            return _permittedWords;
        }
    }
}
