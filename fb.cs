using System;
using System.Diagnostics;

namespace Solutions
{
    class Program
    {
        static void Main()
        {
            var stopWatch = new Stopwatch();
            stopWatch.Start();
            var r = getFibonacciNumberV2(100);
            stopWatch.Stop();

            Console.WriteLine($"Result: {r}; Time: {stopWatch.Elapsed}");
        }

        static int getFibonacciNumberV1(int n)
        {
            Console.WriteLine($"Check numbe {n}");
            if (n == 0)
            {
                return 0;
            }
            else if (n == 1 || n == 2)
            {
                return 1;
            }

            return getFibonacciNumberV1(n - 1) + getFibonacciNumberV1(n - 2);
        }

        static Int64 getFibonacciNumberV2(int n)
        {
            if (n == 0)
            {
                return 0;
            }
            else if (n == 1 || n == 2)
            {
                return 1;
            }

            Int64 first = 1;
            Int64 second = 2;
            Int64 result = 0;

            for (var i = 3; i <= n; i++)
            {
                result = first + second;
                first = second;
                second = result;
                Console.WriteLine($"No. {i} = {result}");
            }

            return result;
        }
    }
}