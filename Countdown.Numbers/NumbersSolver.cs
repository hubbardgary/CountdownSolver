using Countdown.Api.Services.Models;
using Countdown.Numbers.Extensions;
using Countdown.Numbers.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Countdown.Numbers
{
    public class NumbersSolver : INumbersSolver
    {
        private Node Root { get; set; }
        private int Target { get; set; }
        public List<Node> Solutions { get; set; } = new List<Node>();
        public int DistanceFromTarget { get; set; } = 999;
        private IEnumerable<string> Operators => new List<string> { "+", "-", "*", "/" };

        public NumbersSolutionDto Solve(int target, int[] numbers)
        {
            Target = target;
            Root = new Node(numbers);
            GrowSolution(Root);
            Solutions.OrderBy(s => s.Depth);
            return GetSolutionDto();
        }

        public NumbersSolutionDto GetSolutionDto()
        {
            return new NumbersSolutionDto
            {
                Target = Target,
                Numbers = Root.Numbers,
                DistanceFromTarget = DistanceFromTarget,
                Solutions = Formatter.Format(Solutions)
            };
        }

        private void GrowSolution(Node node)
        {
            if (node == null)
                return;

            if (node.Depth > 0)
                CheckAndUpdateSolutions(node);

            foreach (var pairOfOperands in node.Numbers.GetPairs())
                foreach (var operation in Operators)
                    AddChild(node, pairOfOperands, operation);
        }

        // Always return max and min so we don't need to worry about negative numbers or divisions resulting in a value < 1.
        private static (int, int) GetOperands(IEnumerable<int> operands) => (operands.Max(), operands.Min());

        private void AddChild(Node parent, IEnumerable<int> operands, string operation)
        {
            (var x, var y) = GetOperands(operands);
            var expression = new Expression(x, y, operation);
            var newValue = expression.Evaluate();

            if (newValue < 1)
                return;

            var child = new Node(parent, expression, newValue);
            GrowSolution(child);
        }

        private void CheckAndUpdateSolutions(Node node)
        {
            var proximity = Math.Abs(Target - node.CurrentValue);

            if (proximity == 0)
                AddSolution(node);

            else if (proximity <= DistanceFromTarget)
                AddSolution(node, proximity);
        }

        private void AddSolution(Node node)
        {
            if (!node.IsGoodSolution())
                return;

            if (DistanceFromTarget != 0)
            {
                Solutions.Clear();
                DistanceFromTarget = 0;
            }

            Solutions.Add(node);
        }

        private void AddSolution(Node node, int proximity)
        {
            if (proximity == DistanceFromTarget && node.IsGoodSolution())
            {
                Solutions.Add(node);
                return;
            }

            if (proximity < DistanceFromTarget && node.IsGoodSolution())
            {
                DistanceFromTarget = proximity;
                Solutions.Clear();
                Solutions.Add(node);
            }
        }
    }
}
