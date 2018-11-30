using System;

namespace Countdown.Core.Numbers
{
    public class Expression
    {
        public int X { get; set; }
        public int Y { get; set; }
        public string Operation { get; set; }

        public Expression(int operand1, int operand2, string operation)
        {
            X = operand1;
            Y = operand2;
            Operation = operation;
        }

        public int Evaluate()
        {
            switch (Operation)
            {
                case "+":
                    return X + Y;
                case "*":
                    if (X == 1 || Y == 1)
                        return 0;
                    return X * Y;
                case "-":
                    if (X == Y || X - Y == Y)
                        return 0;
                    return X - Y;
                case "/":
                    if (X == 1 || Y == 1 || X % Y != 0 || X / Y == Y)
                        return 0;
                    return X / Y;
                default:
                    throw new Exception("Invalid operation");
            }
        }
    }
}
