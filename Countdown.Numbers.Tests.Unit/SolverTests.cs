using System.Linq;
using Xunit;

namespace Countdown.Numbers.Tests.Unit
{
    public class SolverTests
    {
        private readonly NumbersSolver _numbersPuzzle;

        public SolverTests()
        {
            _numbersPuzzle = new NumbersSolver();
        }

        [Fact]
        public void Solve_ForPuzzleSolvableInOneStep_SolvesPuzzleInOneStep()
        {
            // ACT
            _numbersPuzzle.Solve(150, new[] { 100, 50, 4, 5, 6, 2 });

            // ASSERT
            Assert.Equal(0, _numbersPuzzle.DistanceFromTarget);
            Assert.Equal(1, _numbersPuzzle.Solutions.FirstOrDefault()?.Depth);
        }

        [Fact]
        public void Solve_ForPuzzleWhereBestSolutionIsSixAwayEitherSideOfTarget_ProducesSolutionSixAwayEitherSideOfTarget()
        {
            // ACT
            _numbersPuzzle.Solve(666, new[] { 2, 3, 4, 5, 6, 2 });
            var closestSolutions = _numbersPuzzle.Solutions.Select(s => s.CurrentValue).Distinct();

            // ASSERT
            Assert.Equal(6, _numbersPuzzle.DistanceFromTarget);
            Assert.Equal(2, closestSolutions.Count());
            Assert.Equal(660, closestSolutions.Min());
            Assert.Equal(672, closestSolutions.Max());
        }

        [Theory]
        [InlineData(952, new[] { 100, 25, 50, 75, 6, 3 })]
        [InlineData(700, new[] { 100, 2, 6, 1, 10, 7 })]
        [InlineData(813, new[] { 100, 25, 50, 75, 10, 1 })]
        [InlineData(954, new[] { 25, 9, 5, 2, 6, 5 })]
        public void Solve_SolveablePuzzle_IsSolved(int target, int[] numbers)
        {
            // ACT
            _numbersPuzzle.Solve(target, numbers);
            var solution = _numbersPuzzle.Solutions.Select(s => s.CurrentValue).Distinct();

            // ASSERT
            Assert.Equal(0, _numbersPuzzle.DistanceFromTarget);
            Assert.Equal(1, solution.Count());
            Assert.Equal(target, solution.First());
        }

        // In the following tests, ExpectedResult is the distance away from the target of the best possible solution
        [Theory]
        [InlineData(999, new[] { 1, 1, 2, 2, 3, 3 }, 918)]
        public void Solve_UnsolveablePuzzle_FindsClosestSolution(int target, int[] numbers, int expectedDistanceFromTarget)
        {
            // ACT
            _numbersPuzzle.Solve(target, numbers);

            // ASSERT
            Assert.Equal(expectedDistanceFromTarget, _numbersPuzzle.DistanceFromTarget);
        }
    }
}
