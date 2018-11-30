using System.Collections.Generic;
using System.Linq;

namespace Countdown.Core.Numbers
{
    public class Node
    {
        public int[] Numbers { get; set; }
        public int CurrentValue { get; set; }
        public Expression Expression { get; set; }
        public Node Parent { get; set; }
        public int Depth { get; set; }

        /// <summary>
        /// Initializes a root node
        /// </summary>
        /// <param name="numbers"></param>
        public Node(int[] numbers)
        {
            Numbers = numbers;
            Depth = 0;
            CurrentValue = 0;
        }

        /// <summary>
        /// Initializes a child node based on its parent's values and the operation that has just been performed
        /// </summary>
        /// <param name="parent"></param>
        /// <param name="expression"></param>
        /// <param name="value"></param>
        public Node(Node parent, Expression expression, int value)
        {
            Depth = parent.Depth + 1;
            Numbers = GetNumbersForNewNode(parent.Numbers, expression.X, expression.Y, value);
            Expression = expression;
            CurrentValue = value;
            Parent = parent;
        }

        /// <summary>
        /// Gets available numbers based on the numbers and operations from the parent.
        /// This will be the parent's numbers array with the two operands replaced with the new value.
        /// Use of helper methods to copy and remove items has been avoided to improve performance.
        /// </summary>
        /// <param name="parent"></param>
        /// <param name="operand1"></param>
        /// <param name="operand2"></param>
        /// <param name="newValue"></param>
        /// <returns></returns>
        private int[] GetNumbersForNewNode(int[] parentNumbers, int operand1, int operand2, int newValue)
        {
            var numbers = new int[parentNumbers.Length - 1];
            bool op1Skipped = false;
            bool op2Skipped = false;

            numbers[0] = newValue;
            int idx = 1;
            foreach (var n in parentNumbers)
            {
                if (n == operand1 && !op1Skipped)
                {
                    op1Skipped = true;
                    continue;
                }
                if (n == operand2 && !op2Skipped)
                {
                    op2Skipped = true;
                    continue;
                }
                numbers[idx++] = n;
            }

            return numbers;
        }

        public IEnumerable<Node> GetSolutionSteps()
        {
            List<Node> solutionSteps = new List<Node>();
            var node = this;
            while (node.Parent != null)
            {
                solutionSteps.Add(node);
                node = node.Parent;
            }

            solutionSteps.Reverse();
            return solutionSteps;
        }

        public bool IsGoodSolution()
        {
            if (Depth == 1)
                return true;

            var solutionSteps = GetSolutionSteps();

            // Check that all but the final CurrentValue are referenced again in the calculation.
            // If any aren't referenced, the solution contains at least one unnecessary step and should be discarded.
            for (var i = 0; i < solutionSteps.Count() - 1; i++)
            {
                var stepUsed = false;
                var intermediateVal = solutionSteps.ElementAt(i).CurrentValue;
                for (var j = i + 1; j < solutionSteps.Count(); j++)
                {
                    if (solutionSteps.ElementAt(j).Expression.X == intermediateVal || solutionSteps.ElementAt(j).Expression.Y == intermediateVal)
                    {
                        stepUsed = true;
                        break;
                    }
                }
                if (!stepUsed)
                    return false;
            }
            return true;
        }
    }
}
