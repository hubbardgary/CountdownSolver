using Xunit;

namespace Countdown.Numbers.Tests.Unit
{
    public class ExpressionTests
    {
        [Fact]
        public void Evaluate_Add_ReturnsXPlusY()
        {
            // ARRANGE
            var expression = new Expression(3, 5, "+");
            var expected = expression.X + expression.Y;

            // ACT
            var result = expression.Evaluate();

            // ASSERT
            Assert.Equal(expected, result);
        }

        [Fact]
        public void Evaluate_MultiplyXGreaterThanOneAndYGreaterThanOne_ReturnsXTimesY()
        {
            // ARRANGE
            var expression = new Expression(4, 6, "*");
            var expected = expression.X * expression.Y;

            // ACT
            var result = expression.Evaluate();

            // ASSERT
            Assert.Equal(expected, result);
        }

        [Fact]
        public void Evaluate_MultiplyXEqualsOneAndYIsGreaterThanOne_ReturnsZero()
        {
            // ARRANGE
            var expression = new Expression(1, 6, "*");
            var expected = 0;

            // ACT
            var result = expression.Evaluate();

            // ASSERT
            Assert.Equal(expected, result);
        }

        [Fact]
        public void Evaluate_MultiplyXGreaterThanOneAndYEqualsOne_ReturnsZero()
        {
            // ARRANGE
            var expression = new Expression(4, 1, "*");
            var expected = 0;

            // ACT
            var result = expression.Evaluate();

            // ASSERT
            Assert.Equal(expected, result);
        }

        [Fact]
        public void Evaluate_MultiplyXEqualsOneAndYEqualsOne_ReturnsZero()
        {
            // ARRANGE
            var expression = new Expression(1, 1, "*");
            var expected = 0;

            // ACT
            var result = expression.Evaluate();

            // ASSERT
            Assert.Equal(expected, result);
        }

        [Fact]
        public void Evaluate_SubtractXAndYNotEquals_ReturnsXMinusY()
        {
            // ARRANGE
            var expression = new Expression(7, 3, "-");
            var expected = expression.X - expression.Y;

            // ACT
            var result = expression.Evaluate();

            // ASSERT
            Assert.Equal(expected, result);
        }

        [Fact]
        public void Evaluate_SubtractXEqualsY_ReturnsZero()
        {
            // ARRANGE
            var expression = new Expression(7, 7, "-");
            var expected = 0;

            // ACT
            var result = expression.Evaluate();

            // ASSERT
            Assert.Equal(expected, result);
        }

        [Fact]
        public void Evaluate_SubtractYEquals2X_ReturnsZero()
        {
            // ARRANGE
            var expression = new Expression(14, 7, "-");
            var expected = 0;

            // ACT
            var result = expression.Evaluate();

            // ASSERT
            Assert.Equal(expected, result);
        }

        [Fact]
        public void Evaluate_DivideXIsMultipleOfY_ReturnsXDividedByY()
        {
            // ARRANGE
            var expression = new Expression(20, 5, "/");
            var expected = expression.X / expression.Y;

            // ACT
            var result = expression.Evaluate();

            // ASSERT
            Assert.Equal(expected, result);
        }

        [Fact]
        public void Evaluate_DivideXIsNotMultipleOfY_ReturnsZero()
        {
            // ARRANGE
            var expression = new Expression(21, 5, "/");
            var expected = 0;

            // ACT
            var result = expression.Evaluate();

            // ASSERT
            Assert.Equal(expected, result);
        }

        [Fact]
        public void Evaluate_DivideXDividedByYEqualsY_ReturnsZero()
        {
            // ARRANGE
            var expression = new Expression(4, 2, "/");
            var expected = 0;

            // ACT
            var result = expression.Evaluate();

            // ASSERT
            Assert.Equal(expected, result);
        }

        [Fact]
        public void Evaluate_DivideXEqualsOne_ReturnsZero()
        {
            // ARRANGE
            var expression = new Expression(1, 4, "/");
            var expected = 0;

            // ACT
            var result = expression.Evaluate();

            // ASSERT
            Assert.Equal(expected, result);
        }

        [Fact]
        public void Evaluate_DivideYEqualsOne_ReturnsZero()
        {
            // ARRANGE
            var expression = new Expression(20, 1, "/");
            var expected = 0;

            // ACT
            var result = expression.Evaluate();

            // ASSERT
            Assert.Equal(expected, result);
        }

        [Fact]
        public void Evaluate_DivideXEqualsOneAndYEqualsOne_ReturnsZero()
        {
            // ARRANGE
            var expression = new Expression(1, 1, "/");
            var expected = 0;

            // ACT
            var result = expression.Evaluate();

            // ASSERT
            Assert.Equal(expected, result);
        }
    }
}
