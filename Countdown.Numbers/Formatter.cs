using System;
using System.Collections.Generic;

namespace Countdown.Numbers
{
    public static class Formatter
    {
        public static IEnumerable<string> Format(List<Node> solutions)
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
                formattedSolutions.Add(formattedSolution);

            }
            return formattedSolutions;
        }
    }
}
