using Countdown.Core.Numbers;
using System.Linq;
using Xunit;

namespace Countdown.Numbers.Tests.Unit
{
    public class NodeTests
    {
        private Node _goodSolutionRoot;
        private Node _goodSolutionChild1;
        private Node _goodSolutionChild2;
        private Node _goodSolutionChild3;

        private Node _badSolutionRoot;
        private Node _badSolutionChild1;
        private Node _badSolutionChild2;
        private Node _badSolutionChild3;

        public NodeTests()
        {
            _goodSolutionRoot = new Node(new[] { 1, 3, 8, 10 });
            _goodSolutionChild1 = new Node(_goodSolutionRoot, new Expression(1, 3, "+"), 4);
            _goodSolutionChild2 = new Node(_goodSolutionChild1, new Expression(8, 10, "+"), 18);
            _goodSolutionChild3 = new Node(_goodSolutionChild2, new Expression(4, 18, "+"), 22);

            _badSolutionRoot = new Node(new[] { 1, 3, 8, 10, 25 });
            _badSolutionChild1 = new Node(_badSolutionRoot, new Expression(1, 3, "+"), 4);
            _badSolutionChild2 = new Node(_badSolutionChild1, new Expression(8, 10, "+"), 18);
            _badSolutionChild3 = new Node(_badSolutionChild2, new Expression(4, 25, "+"), 29);
        }

        [Fact]
        public void GetSolutionSteps_ForSolutionWithThreeSteps_ReturnsThreeNodes()
        {
            var expectedLength = 3;

            // ACT
            var result = _goodSolutionChild3.GetSolutionSteps();

            // ASSERT
            Assert.Equal(expectedLength, result.Count());
        }

        [Fact]
        public void IsGoodSolution_ForSolutionWithNoRedundantSteps_ReturnsTrue()
        {
            // ACT
            var result = _goodSolutionChild3.IsGoodSolution();

            // ASSERT
            Assert.Equal(true, result);
        }

        [Fact]
        public void IsGoodSolution_ForSolutionWithRedundantSteps_ReturnsFalse()
        {
            // ACT
            var result = _badSolutionChild3.IsGoodSolution();

            // ASSERT
            Assert.Equal(false, result);
        }
    }
}
