using Countdown.Api.Services.Interfaces;
using Countdown.Api.Controllers;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace Countdown.Api.Tests.Unit
{
    public class LettersControllerTests
    {
        LettersController lettersController;
        Mock<ILettersService> lettersServiceMock;

        public LettersControllerTests()
        {
            lettersServiceMock = new Mock<ILettersService>();
            lettersController = new LettersController(lettersServiceMock.Object);
        }

        [Theory]
        [InlineData(new[] { 'a' })]
        [InlineData(new[] { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h' })]
        [InlineData(new[] { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j' })]
        public void Solve_CalledWithFewerOrMoreThanNineLetters_Returns400(char[] letters)
        {
            // ACT
            var result = lettersController.Solve(letters);

            // ASSERT
            Assert.IsType(typeof(BadRequestObjectResult), result);
            Assert.Equal(400, ((BadRequestObjectResult)result).StatusCode);
            Assert.Equal("letters must have a length of 9", ((BadRequestObjectResult)result).Value);
        }

        [Theory]
        [InlineData(new[] { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i' })]
        public void Solve_CalledWithNineLetters_ReturnsOk(char[] letters)
        {
            // ACT
            var result = lettersController.Solve(letters);

            // ASSERT
            Assert.IsType(typeof(OkObjectResult), result);
            lettersServiceMock.Verify(x => x.GetSolutions(letters), Times.Once);
        }
    }
}
