using Countdown.Letters.Interfaces;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Countdown.Letters
{
    public class WordListSowpods : IWordList
    {
        private const string _filename = @"dictionaries\sowpods.txt";
        private readonly IEnumerable<string> _permittedWords;

        public WordListSowpods()
        {
            _permittedWords = File
                .ReadAllLines(_filename)
                .Where(w => w.Length <= 9);
        }
        public IEnumerable<string> Words()
        {
            return _permittedWords;
        }
    }
}
