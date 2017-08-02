using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Countdown.Letters
{
    public class WordList
    {
        private readonly IEnumerable<string> _permittedWords;

        public IEnumerable<string> Words => _permittedWords;

        public WordList(IEnumerable<string> permittedWords)
        {
            _permittedWords = permittedWords;
        }

        public WordList(string filename)
        {
            _permittedWords = File
                .ReadAllLines(filename)
                .Where(w => w.Length <= 9);
        }
    }
}
