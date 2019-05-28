https://www.hackerrank.com/challenges/drawing-book/problem

using System;

namespace Solutions
{
    class Program
    {
        static int pageCount(int n, int p)
        {
            var fromFront = 0;

            if (p % 2 == 0)
            {
                fromFront = p / 2;
            }
            else
            {
                fromFront = (p - 1) / 2;
            }

            var fromBack = 0;

            if (n % 2 == 0)
            {
                n += 1;
            }

            if (p % 2 == 1)
            {
                p -= 1;
            }

            fromBack = (n - p) / 2;

            return fromBack > fromFront ? fromFront : fromBack;

        }

        static void Main(string[] args)
        {
            Console.WriteLine(pageCount(7, 4));

            Console.WriteLine(pageCount(6, 5));

            Console.WriteLine(pageCount(37455, 29835));

        }
    }
}