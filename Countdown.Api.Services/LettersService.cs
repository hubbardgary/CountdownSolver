using Countdown.Api.Services.Interfaces;
using Countdown.Letters.Interfaces;
using System.Collections.Generic;

namespace Countdown.Api.Services
{
    public class LettersService : ILettersService
    {
        private readonly ILettersSolver _lettersSolver;

        public LettersService(ILettersSolver letterSolver)
        {
            _lettersSolver = letterSolver;
        }

        public IDictionary<int, List<string>> GetSolutions(char[] letters)
        {
            return _lettersSolver.Solve(letters);
        }
    }
}
