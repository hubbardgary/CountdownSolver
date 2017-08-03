using Countdown.Letters;
using Countdown.Numbers;
using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            var letters = new[] { 'b', 'e', 'd', 'd', 'a', 'r', 's', 'a', 'p' };
            var lettersSolver = new LettersSolver(new WordFinder(new WordListSowpods()));
            lettersSolver.Solve(letters);


            //var numbers = new[] { 1, 7, 9, 10, 25, 100 };
            //var target = 190;
            //var numbers = new[] { 2, 3, 4, 5, 6, 2 };
            //var target = 666;
            var numbers = new[] { 25, 1, 3, 2, 1, 4 };
            var target = 549;

            var numbersSolver = new NumbersSolver();
            numbersSolver.Solve(target, numbers);

            Console.WriteLine($"The numbers were {string.Join(" ", numbers)}");
            Console.WriteLine($"The target was {target}");
            Console.WriteLine();

            if (numbersSolver.DistanceFromTarget == 0)
            {
                Console.WriteLine($"Found {numbersSolver.Solutions.Count} solutions:");
            }
            else
            {
                Console.WriteLine($"There is no solution. The best possible is {numbersSolver.DistanceFromTarget} away, of which the following {numbersSolver.Solutions.Count} were found:");
            }
            Console.WriteLine();

            foreach (var solution in Formatter.Format(numbersSolver.Solutions))
            {
                Console.WriteLine(solution);
            }

            Console.ReadKey();
        }
    }
}