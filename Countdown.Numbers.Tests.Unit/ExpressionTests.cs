using System;
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

        [Theory]
        [InlineData("1", 2, 3)]
        public void TheoryTest(string one, int two, decimal three)
        {
            Assert.Equal("1", one);
            Assert.Equal(2, two);
            Assert.Equal(4, three);
        }
    }
}
