using System;
using System.Collections.Generic;

namespace Countdown.Core.Numbers
{
    public static class Formatter
    {
        public static IEnumerable<string> Format(IEnumerable<Node> solutions)
        {
            var formattedSolutions = new List<string>();

            foreach (var solution in solutions)
            {
                var node = solution;
                var formattedSolution = "";
                while (node.Parent != null)
                {
                    formattedSolution = $"{node.Expression.X} {node.Expression.Operation} {node.Expression.Y} = {node.CurrentValue}{Environment.NewLine}{formattedSolution}";
                    node = node.Parent;
                }

                if (!formattedSolutions.Contains(formattedSolution))
                {
                    formattedSolutions.Add(formattedSolution);
                }

            }
            return formattedSolutions;
        }
    }
}
