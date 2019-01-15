using Countdown.Core.Letters.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Countdown.Core.Letters
{
    public class WordFinder : IWordFinder
    {
        private readonly IWordList _wordList;

        public WordFinder(IWordList wordList)
        {
            _wordList = wordList;
        }

        public IEnumerable<string> FindWordsFromLetters(IEnumerable<char> letters)
        {
            return _wordList.Words()
                .Where(w => LettersMakeWord(w, letters));
        }

        public bool LettersMakeWord(string word, IEnumerable<char> letters)
        {
            var sortedWord = string.Join("", word.ToLower().OrderBy(x => x));
            var sortedLetters = letters.Select(l => char.ToLower(l)).OrderBy(l => l);

            var lettersIdx = 0;

            for (var wordIdx = 0; wordIdx < sortedWord.Length; wordIdx++)
            {
                while (lettersIdx < sortedLetters.Count())
                {
                    if (sortedLetters.ElementAt(lettersIdx) == sortedWord[wordIdx])
                    {
                        if (wordIdx == sortedWord.Length - 1)
                            return true;

                        lettersIdx++;
                        break;
                    }
                    if (lettersIdx == sortedLetters.Count() - 1)
                    {
                        return false;
                    }
                    lettersIdx++;
                }
            }
            return false;
        }
    }
}
