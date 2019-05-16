using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text.RegularExpressions;
using System.Text;
using System;

namespace Algorithms
{
    class Solution
    {
        static void Main(string[] args)
        {
            int[][] arr = new int[6][];

            arr[0] = "-1 -1 0 -9 -2 -2".Split(' ').Select(x=>int.Parse(x)).ToArray();
            arr[1] = "-2 -1 -6 -8 -2 -5".Split(' ').Select(x=>int.Parse(x)).ToArray();
            arr[2] = "-1 -1 -1 -2 -3 -4".Split(' ').Select(x=>int.Parse(x)).ToArray();
            arr[3] = "-1 -9 -2 -4 -4 -5".Split(' ').Select(x=>int.Parse(x)).ToArray();
            arr[4] = "-7 -3 -3 -2 -9 -9".Split(' ').Select(x=>int.Parse(x)).ToArray();
            arr[5] = "-1 -3 -1 -2 -4 -5".Split(' ').Select(x=>int.Parse(x)).ToArray();

            long maximum = int.MinValue;
            for (var i = 1; i < 5; i++)
            {
                for (var j = 1; j < 5; j++)
                {
                    long total = arr[i - 1][j - 1];
                    total += arr[i - 1][j];
                    total += arr[i - 1][j + 1];
                    total += arr[i][j];
                    total += arr[i + 1][j - 1];
                    total += arr[i + 1][j];
                    total += arr[i + 1][j + 1];
                    if (total > maximum)
                    {
                        maximum = total;
                    }
                }
            }

            Console.WriteLine(maximum);
        }
    }
}