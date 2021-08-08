using System;
using System.Collections.Generic;

namespace HarryPotterSpells
{
    class Program
    {
        private static readonly Dictionary<int, Func<int, int, bool>> Spells = new();
        private const int SquareWidth = 25;

        static void Main(string[] args)
        {
            Spells.Add(1, (x, y) => x < y);
            Spells.Add(2, (x, y) => x == y);
            Spells.Add(3, (x, y) => x + y == SquareWidth - 1);
            Spells.Add(4, (x, y) => x + y - 5 < SquareWidth);
            Spells.Add(5, (x, y) => y / 2 == x);
            Spells.Add(6, (x, y) => x < 10 || y < 10);
            Spells.Add(7, (x, y) => x > SquareWidth - 10 && y > SquareWidth - 10);
            Spells.Add(8, (x, y) => x * y == 0);
            Spells.Add(9, (x, y) => x - 10 > y || x + 10 < y);
            Spells.Add(10, (x, y) => x < y && 2 * x + 2 > y);
            Spells.Add(11, (x, y) => x == 1 || x == SquareWidth - 2 || y == 1 || y == SquareWidth - 2);
            Spells.Add(12, (x, y) => x * x + y * y <= 400);
            Spells.Add(13, (x, y) => x + y > SquareWidth - 6 && x + y < SquareWidth + 4);
            Spells.Add(14, (x, y) => (x - SquareWidth + 1) * (x - SquareWidth + 1) + (y - SquareWidth + 1) * (y - SquareWidth + ) > 225);
            Spells.Add(15, (x, y) => (x - 10 > y && x - SquareWidth + 4 < y) || (y - 9 > x && y - SquareWidth + 4 < x));
            Spells.Add(16, (x, y) => Math.Abs(x - 12) + Math.Abs(y - 12) < 10);

            foreach (var s in Spells)
            {
                Console.WriteLine($"Picture №{s.Key}");
                for (int x = 0; x < SquareWidth; ++x)
                {
                    for (int y = 0; y < SquareWidth; ++y)
                        Console.Write(s.Value(x, y) ? "# " : ". ");
                    Console.WriteLine();
                }

                Console.ReadKey();
                Console.Clear();
            }

            Console.WriteLine("Spells were executed");
            Console.ReadKey();
        }
    }
}