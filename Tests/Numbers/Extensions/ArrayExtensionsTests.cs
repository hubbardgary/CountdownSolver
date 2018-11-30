using Countdown.Core.Numbers.Extensions;
using System.Linq;
using Xunit;

namespace Countdown.Numbers.Tests.Unit.Extensions
{
    public class ArrayExtensionsTests
    {
        [Fact]
        public void GetPairs_ForArrayOfInts_ReturnsCollectionOfPairs()
        {
            // ARRANGE
            var ints = new[] { 1, 2, 3 };
            var expected = new[]
            {
                new [] { 1, 2 },
                new [] { 1, 3 },
                new [] { 2, 3 }
            };

            // ACT
            var result = ints.GetPairs();

            // ASSERT
            Assert.Equal(expected.Count(), result.Count());
            Assert.Equal(expected[0][0], result.ElementAt(0)[0]);
            Assert.Equal(expected[0][1], result.ElementAt(0)[1]);
            Assert.Equal(expected[1][0], result.ElementAt(1)[0]);
            Assert.Equal(expected[1][1], result.ElementAt(1)[1]);
            Assert.Equal(expected[2][0], result.ElementAt(2)[0]);
            Assert.Equal(expected[2][1], result.ElementAt(2)[1]);
        }
    }
}
