using Countdown.Core.Letters;
using Countdown.Core.Letters.Interfaces;
using Moq;
using System.Collections.Generic;
using Xunit;

namespace Countdown.Letters.Tests.Unit
{
    public class LettersSolverTests
    {
        Mock<IWordFinder> wordFinderMock;
        ILettersSolver lettersSolver;

        public LettersSolverTests()
        {
            wordFinderMock = new Mock<IWordFinder>();
            wordFinderMock.Setup(x => x.FindWordsFromLetters(It.IsAny<char[]>())).Returns(new List<string> { "one", "two", "three" });
            lettersSolver = new LettersSolver(wordFinderMock.Object);
        }

        [Fact]
        public void Solve_UsingMockedData_ReturnsDictionaryWithCorrectAmountOfEntries()
        {
            // ACT
            var result = lettersSolver.Solve(new char[] { });

            // ASSERT
            Assert.Equal(2, result.Count);
            Assert.Equal(2, result[3].Count);
            Assert.Equal(1, result[5].Count);
            Assert.Throws<KeyNotFoundException>(() => result[4]);
        }

        [Fact]
        public void Solve_UsingMockedData_ReturnsDictionaryWithCorrectWords()
        {
            // ACT
            var result = lettersSolver.Solve(new char[] { });

            // ASSERT
            var threeLetterWords = result[3];
            var fiveLetterWords = result[5];
            Assert.Contains("one", threeLetterWords);
            Assert.Contains("two", threeLetterWords);
            Assert.Contains("three", fiveLetterWords);
        }

        [Fact]
        public void Solve_UsingMockedData_CallsFindWordsFromLetters()
        {
            // ACT
            var result = lettersSolver.Solve(new char[] { });

            // ASSERT
            wordFinderMock.Verify(x => x.FindWordsFromLetters(new char[] { }), Times.Once);
        }
    }
}
