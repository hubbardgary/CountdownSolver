﻿using System.Collections.Generic;

namespace Countdown.Letters.Interfaces
{
    public interface IWordFinder
    {
        IEnumerable<string> FindWordsFromLetters(IEnumerable<char> letters);
        bool LettersMakeWord(string word, IEnumerable<char> letters);
    }
}
