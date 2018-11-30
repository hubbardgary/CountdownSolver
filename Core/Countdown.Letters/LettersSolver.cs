using Countdown.Core.Letters.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Countdown.Core.Letters
{
    public class LettersSolver : ILettersSolver
    {
        private readonly IWordFinder _wordFinder;

        public LettersSolver(IWordFinder wordFinder)
        {
            _wordFinder = wordFinder;
        }

        public IDictionary<int, List<string>> Solve(char[] letters)
        {
            //var wordList = new WordList(@"C:\Users\Gary Hubbard\Documents\LINQPad Queries\Countdown2017\Letters\sowpods.txt");
            //var wordFinder = new WordFinder(wordList);

            var sortedLetters = letters.OrderBy(l => l).ToArray();
            var matchedWords = _wordFinder.FindWordsFromLetters(letters);

            return matchedWords
                .GroupBy(x => x.Length)
                .ToDictionary(g => g.Key, g => g.ToList());
        }
    }
}
