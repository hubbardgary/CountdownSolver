﻿using System.Collections.Generic;
using System.Linq;

namespace Countdown.Letters
{
    public class WordFinder
    {
        private readonly WordList _wordList;

        public WordFinder(WordList wordList)
        {
            _wordList = wordList;
        }

        public IEnumerable<string> FindWordsFromLetters(IEnumerable<char> letters)
        {
            return _wordList.Words
                .Where(w => LettersMakeWord(w, letters));
        }

        public bool LettersMakeWord(string word, IEnumerable<char> letters)
        {
            var sortedWord = string.Join("", word.OrderBy(x => x)).ToLower();
            var sortedLetters = letters.OrderBy(l => l).ToArray();

            var lettersIdx = 0;

            for (var wordIdx = 0; wordIdx < sortedWord.Length; wordIdx++)
            {
                while (lettersIdx < sortedLetters.Length)
                {
                    if (sortedLetters[lettersIdx] == sortedWord[wordIdx])
                    {
                        if (wordIdx == sortedWord.Length - 1)
                            return true;

                        lettersIdx++;
                        break;
                    }
                    if (lettersIdx == sortedLetters.Length - 1)
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
