using Countdown.Core.Letters;
using Countdown.Core.Letters.Interfaces;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Countdown.Letters.Tests.Unit
{
    public class WordFinderTests
    {
        private IWordList _wordList;
        private IWordFinder _wordFinder;

        public WordFinderTests()
        {
            _wordList = new WordListUserDefined(new List<string>
            {
                "elephant",
                "monkey",
                "ant",
                "orangutan",
                "armadillo",
                "goat",
                "giraffe"
            });

            _wordFinder = new WordFinder(_wordList);
        }

        [Theory]
        [InlineData("hello", new[] { 'a', 'b', 'e', 'l', 'h', 'o', 'h' })]
        [InlineData("zzz", new[] { 'z', 'z' })]
        [InlineData("bananas", new[] { 'a', 'b', 'a', 'm', 'm', 'o', 'h', 'e', 's' })]
        [InlineData("pyjamas", new[] { 'p', 'i', 'j', 'm', 'a', 'f', 'x', 'b', 's' })]
        public void LettersMakeWord_FailureTest_ReturnsFalse(string word, char[] letters)
        {
            // ACT
            var result = _wordFinder.LettersMakeWord(word, letters);

            // ASSERT
            Assert.Equal(false, result);
        }

        [Theory]
        [InlineData("hello", new[] { 'l', 'b', 'e', 'l', 'h', 'o', 'h' })]
        [InlineData("zzz", new[] { 'z', 'z', 'z' })]
        [InlineData("bananas", new[] { 'a', 'b', 'a', 'n', 'n', 'o', 'a', 'e', 's' })]
        [InlineData("pyjamas", new[] { 'p', 'y', 'j', 'm', 'a', 'f', 'x', 'a', 's' })]
        public void LettersMakeWord_SuccessTest_ReturnsTrue(string word, char[] letters)
        {
            // ACT
            var result = _wordFinder.LettersMakeWord(word, letters);

            // ASSERT
            Assert.Equal(true, result);
        }

        [Theory]
        [InlineData(new[] { 'a', 'n', 'e', 'e', 'l', 'p', 't', 'n', 'h' }, new[] { "elephant", "ant" })]
        [InlineData(new[] { 'a', 'n', 'e', 'm', 'o', 'y', 't', 'n', 'k' }, new[] { "ant", "monkey" })]
        [InlineData(new[] { 'i', 'n', 'e', 'g', 'o', 'a', 'r', 'f', 'f' }, new[] { "giraffe" })]
        [InlineData(new[] { 't', 'o', 'r', 'g', 'n', 'a', 'a', 'u', 'n' }, new[] { "ant", "goat", "orangutan" })]
        [InlineData(new[] { 'd', 'l', 'r', 'm', 'l', 'a', 'a', 'o', 'i' }, new[] { "armadillo" })]
        [InlineData(new[] { 'd', 'l', 'r', 'm', 'm', 'a', 'a', 'o', 'i' }, new string[] { })]
        public void FindWordsFromLetters_ForVarietyOfWords_ReturnsListOfFoundWords(IEnumerable<char> letters, IEnumerable<string> expectedResults)
        {
            // ACT
            var results = _wordFinder.FindWordsFromLetters(letters).ToList();

            // ASSERT
            Assert.Equal(expectedResults.Count(), results.Count());

            foreach (var expectedResult in expectedResults)
            {
                Assert.Contains(expectedResult, results);
            }
        }

        [Theory]
        [InlineData(new[] { 't', 'o', 'r', 'g', 'n', 'a', 'a', 'u', 'n' }, new[] { "ant", "goat", "orangutan" })]
        [InlineData(new[] { 'T', 'o', 'R', 'g', 'N', 'a', 'A', 'u', 'N' }, new[] { "ant", "goat", "orangutan" })]
        [InlineData(new[] { 'T', 'O', 'R', 'G', 'N', 'A', 'A', 'U', 'N' }, new[] { "ant", "goat", "orangutan" })]
        public void FindWordsFromLetters_ForMixedCaseLetters_ReturnsListOfFoundWords(IEnumerable<char> letters, IEnumerable<string> expectedResults)
        {
            // ACT
            var results = _wordFinder.FindWordsFromLetters(letters).ToList();

            // ASSERT
            Assert.Equal(expectedResults.Count(), results.Count());

            foreach (var expectedResult in expectedResults)
            {
                Assert.Contains(expectedResult, results);
            }
        }
    }
}
