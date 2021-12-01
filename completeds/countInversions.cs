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

class Solutionzz
{

    // Complete the countInversions function below.
    static long countInversions(int[] arr)
    {
        return sort(arr, new int[arr.Length], 0, arr.Length - 1) / 2;
    }

    static long sort(int[] arr, int[] temp, int left, int right)
    {
        if (left >= right)
        {
            return 0;
        }

        long swap = 0;
        var middle = (left + right) / 2;
        swap += sort(arr, temp, left, middle);
        swap += sort(arr, temp, middle + 1, right);

        swap += mergeHalves(arr, temp, left, right);

        return swap;

    }

    static long mergeHalves(int[] arr, int[] temp, int left, int right)
    {
        long swap = 0;

        var middle = (left + right) / 2;

        var leftStart = left;
        var index = leftStart;

        var leftEnd = middle;

        var rightStart = middle + 1;
        var rightEnd = right;

        while (leftStart <= leftEnd && rightStart <= rightEnd)
        {
            if (arr[leftStart] <= arr[rightStart])
            {
                temp[index] = arr[leftStart];
                swap += Math.Abs(leftStart - index);
                leftStart++;
            }
            else if (arr[leftStart] > arr[rightStart])
            {
                temp[index] = arr[rightStart];
                swap += Math.Abs(rightStart - index);
                rightStart++;
            }

            index++;
        }

        for (var i = leftStart; i <= leftEnd; i++)
        {
            temp[index] = arr[i];
            swap += Math.Abs(i - index);
            index++;
        }

        for (var i = rightStart; i <= rightEnd; i++)
        {
            temp[index] = arr[i];
            swap += Math.Abs(i - index);
            index++;
        }

        for (var i = left; i <= right; i++)
        {
            arr[i] = temp[i];
        }

        return swap;

    }



    static void Main(string[] args)
    {
        int[] arr = Array.ConvertAll("2 1 3 1 2".Split(' '), arrTemp => Convert.ToInt32(arrTemp));
        long result = countInversions(arr);
        Console.WriteLine($"2 1 3 1 2 Expect: 4, Result: {result}");

        arr = Array.ConvertAll("1 1 1 2 2".Split(' '), arrTemp => Convert.ToInt32(arrTemp));
        result = countInversions(arr);
        Console.WriteLine($"1 1 1 2 2 Expect: 0, Result: {result}");

        arr = Array.ConvertAll("1 5 3 7".Split(' '), arrTemp => Convert.ToInt32(arrTemp));
        result = countInversions(arr);
        Console.WriteLine($"1 5 3 7 Expect: 1, Result: {result}");

        arr = Array.ConvertAll("7 5 3 1".Split(' '), arrTemp => Convert.ToInt32(arrTemp));
        result = countInversions(arr);
        Console.WriteLine($"7 5 3 1 Expect: 6, Result: {result}");
    }
}
