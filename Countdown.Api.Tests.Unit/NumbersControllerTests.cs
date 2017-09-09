using Countdown.Api.Services.Interfaces;
using Countdown.Api.Controllers;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace Countdown.Api.Tests.Unit
{
    public class NumbersControllerTests
    {
        NumbersController numbersController;
        Mock<INumbersService> numbersServiceMock;

        public NumbersControllerTests()
        {
            numbersServiceMock = new Mock<INumbersService>();
            numbersController = new NumbersController(numbersServiceMock.Object);
        }

        [Theory]
        [InlineData(100, new[] { 1 })]
        [InlineData(100, new[] { 1, 2, 3, 4, 100 })]
        [InlineData(100, new[] { 1, 2, 3, 4, 25, 50, 75 })]
        public void Solve_CalledWithFewerOrMoreThanSixNumbers_Returns400(int target, int[] numbers)
        {
            // ACT
            var result = numbersController.Solve(target, numbers);

            // ASSERT
            Assert.IsType(typeof(BadRequestObjectResult), result);
            Assert.Equal(400, ((BadRequestObjectResult)result).StatusCode);
            Assert.Equal("nums must have a length of 6", ((BadRequestObjectResult)result).Value);
        }

        [Theory]
        [InlineData(99, new[] { 1, 2, 3, 25, 50, 75 })]
        public void Solve_CalledWithTargetLessThan100_Returns400(int target, int[] numbers)
        {
            // ACT
            var result = numbersController.Solve(target, numbers);

            // ASSERT
            Assert.IsType(typeof(BadRequestObjectResult), result);
            Assert.Equal(400, ((BadRequestObjectResult)result).StatusCode);
            Assert.Equal("target must be between 100 and 999 inclusive", ((BadRequestObjectResult)result).Value);
        }

        [Theory]
        [InlineData(1000, new[] { 1, 2, 3, 25, 50, 75 })]
        public void Solve_CalledWithTargetGreaterThan999_Returns400(int target, int[] numbers)
        {
            // ACT
            var result = numbersController.Solve(target, numbers);

            // ASSERT
            Assert.IsType(typeof(BadRequestObjectResult), result);
            Assert.Equal(400, ((BadRequestObjectResult)result).StatusCode);
            Assert.Equal("target must be between 100 and 999 inclusive", ((BadRequestObjectResult)result).Value);
        }

        [Theory]
        [InlineData(500, new[] { 1, 2, 3, 25, 50, 75 })]
        public void Solve_CalledWithNineLetters_ReturnsOkResult(int target, int[] numbers)
        {
            // ACT
            var result = numbersController.Solve(target, numbers);

            // ASSERT
            Assert.IsType(typeof(OkObjectResult), result);
            numbersServiceMock.Verify(x => x.GetSolutions(target, numbers), Times.Once);
        }
    }
}
