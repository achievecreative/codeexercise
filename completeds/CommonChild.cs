using System;
using System.Linq;


namespace Solutions
{
    class Program
    {
        static int commonChild(string s1, string s2)
        {
            var max = 0;

            int[,] c = new int[s1.Length + 1, s2.Length + 1];
            for (int i = 1; i <= s1.Length; i++)
            {
                var a = s1[i - 1];

                for (int j = 1; j <= s2.Length; j++)
                {
                    var b = s2[j - 1];

                    if (s1[i - 1] == s2[j - 1])
                    {
                        c[i, j] = c[i - 1, j - 1] + 1;
                    }
                    else
                    {
                        c[i, j] = c[i - 1, j] > c[i, j - 1] ? c[i - 1, j] : c[i, j - 1];
                    }

                    if (c[i, j] > max)
                    {
                        max = c[i, j];
                    }
                }
            }
            return max;
        }

        static void Main(string[] args)
        {
            var r = 0;

            r = commonChild("ABC", "BCD");
            Console.WriteLine(r);

            r = commonChild("OUDFRMYMAW", "AWHYFCCMQX");
            Console.WriteLine(r);

            r = commonChild("WEWOUCUIDGCGTRMEZEPXZFEJWISRSBBSYXAYDFEJJDLEBVHHKS", "FDAGCXGKCTKWNECHMRXZWMLRYUCOCZHJRRJBOAJOQJZZVUYXIC");
            Console.WriteLine(r);
        }
    }

}