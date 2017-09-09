using Countdown.Letters.Interfaces;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace Countdown.Letters
{
    public class WordListSowpods : IWordList
    {
        private readonly string _filename = $"{Path.GetDirectoryName(Assembly.GetEntryAssembly().Location)}/dictionaries/sowpods.txt";
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
