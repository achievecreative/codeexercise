using System;
using System.Collections.Generic;
using System.Linq;

namespace Solutions
{
    class Programm
    {
        static string encryption(string s)
        {
            s = s.Replace(" ", string.Empty);

            var row = (int)Math.Sqrt(s.Length);

            var columns = row + 1;

            if (row * row == s.Length)
            {
                columns = row;
            }
            else
            {
                if (row * columns < s.Length)
                {
                    row++;
                }
            }

            var list = new List<string>();

            var rowIndex = 0;
            do
            {
                var startIndex = rowIndex * columns;
                var length = Math.Min(s.Length - startIndex, columns);
                if (length == 0)
                {
                    break;
                }
                var substr = s.Substring(startIndex, length);
                list.Add(substr);
                rowIndex++;
            } while (rowIndex < row);

            var results = new List<string>();
            for (var i = 0; i < columns; i++)
            {
                var sub = "";
                list.ForEach(value =>
                {
                    if (value.Length > i)
                    {
                        sub += value[i];
                    }
                });

                results.Add(sub);
            }

            return string.Join(" ", results);
        }

        static void Main(string[] args)
        {
            var r = encryption("haveaniceday");
            Console.WriteLine(r);

            r = encryption("chillout");
            Console.WriteLine(r);

            r = encryption("wclwfoznbmyycxvaxagjhtexdkwjqhlojykopldsxesbbnezqmixfpujbssrbfhlgubvfhpfliimvmnny");
            Console.WriteLine(r);
        }

    }

}