//https://www.hackerrank.com/challenges/day-of-the-programmer/problem
using System;

namespace Solutions
{
    class Program
    {
        static string dayOfProgrammer(int year)
        {
            var daysOfProgram = 256;
            int[] months = new int[12] { 31, 29, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };
            var isLeapYear = year > 1918 ? (year % 400 == 0 || (year % 4 == 0 && year % 100 != 0)) : year % 4 == 0;

            if (isLeapYear)
            {
                months[1] = 29;
            }
            else
            {
                months[1] = 28;
            }

            if (year == 1918)
            {
                months[1] = months[1] - 13;
            }

            var month = 0;
            while (daysOfProgram >= months[month])
            {
                daysOfProgram = daysOfProgram - months[month];
                month++;
            }

            return $"{daysOfProgram}.{(month + 1):00}.{year}";
        }
    }
}