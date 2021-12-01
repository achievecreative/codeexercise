using System;

namespace Solutions
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(getFibonacciNumber(1000));
        }

        static int getFibonacciNumber(int n)
        {
            if (n < 0)
            {
                return 0;
            }
            else if (n <= 2)
            {
                return n;
            }

            var first = 1;
            var second = 2;
            var result = 0;

            for (var i = 3; i <= n; i++)
            {
                result = first + second;
                first = second;
                second = result;
            }

            return result;
        }
    }
}