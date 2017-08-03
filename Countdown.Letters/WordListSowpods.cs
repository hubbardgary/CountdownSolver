using Countdown.Letters.Interfaces;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Countdown.Letters
{
    public class WordListSowpods : IWordList
    {
        private const string _filename = @"C:\Users\Gary Hubbard\Documents\LINQPad Queries\Countdown2017\Letters\sowpods.txt";
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
