using System;
using System.Collections.Generic;
using System.Linq;

namespace Solutions
{
    class Programm
    {
        static string biggerIsGreater(string w)
        {
            if (w.Length < 2)
            {
                return "no answer";
            }

            var array = w.ToArray();

            var index = array.Length - 1;
            var foundIndex = -1;
            do
            {
                var last = array[index];
                for (var i = index - 1; i >= 0; i--)
                {
                    if (array[i] < array[index])
                    {
                        foundIndex = i;
                        break;
                    }
                }

                if (foundIndex >= 0)
                {
                    break;
                }
                index--;
            }
            while (index > 0);

            if (foundIndex >= 0)
            {
                var t = array[foundIndex];
                array[foundIndex] = array[index];
                array[index] = t;

                return string.Join("", array.Select(x => x.ToString()).ToArray(), 0, foundIndex + 1) + string.Join("", array.Skip(foundIndex + 1).OrderBy(x => x));
            }

            return "no answer";
        }

        static string biggerIsGreater2(string w)
        {
            if (w.Length < 2)
            {
                return "no answer";
            }

            var array = w.ToArray().Select(x=>x.ToString()).ToArray();

            var foundIndex = -1;

            var found = false;
            var i = array.Length - 1;
            while (i > 0)
            {
                if (array[i - 1].CompareTo(array[i]) < 0)
                {
                    found = true;
                    break;
                }
                i--;
            }

            if (!found)
            {
                return "no answer";
            }

            foundIndex = i - 1;

            var indexToSwitch = -1;
            for (var j = array.Length - 1; j > foundIndex; j--)
            {
                if (array[j].CompareTo(array[foundIndex]) > 0)
                {
                    indexToSwitch = j;
                    break;
                }
            }

            var t = array[foundIndex];
            array[foundIndex] = array[indexToSwitch];
            array[indexToSwitch] = t;

            return string.Join("", array, 0, foundIndex + 1) + string.Join("", array.Skip(foundIndex + 1).OrderBy(x => x));
        }

        static void Main(string[] args)
        {
            var r = biggerIsGreater("lmno");
            Console.WriteLine(r);

            r = biggerIsGreater("fedcbabcd");
            Console.WriteLine(r);

            r = biggerIsGreater("dkhc");
            Console.WriteLine(r);

            r = biggerIsGreater2("aa");
            Console.WriteLine(r);

            r = biggerIsGreater2("dkhc");
            Console.WriteLine(r);
        }
    }
}