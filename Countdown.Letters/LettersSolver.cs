using System.Collections.Generic;
using System.Linq;

namespace Countdown.Letters
{
    public class LettersSolver
    {
        public char[] Letters { get; set; }
        public IDictionary<int, List<string>> Solutions { get; set; }

        public LettersSolver(char[] letters)
        {
            Letters = letters;
        }

        public void Solve()
        {
            var wordList = new WordList(@"C:\Users\Gary Hubbard\Documents\LINQPad Queries\Countdown2017\Letters\sowpods.txt");
            var wordFinder = new WordFinder(wordList);

            var sortedLetters = Letters.OrderBy(l => l).ToArray();
            var matchedWords = wordFinder.FindWordsFromLetters(Letters);

            Solutions = matchedWords
                .GroupBy(x => x.Length)
                .ToDictionary(g => g.Key, g => g.ToList());
        }
    }
}
