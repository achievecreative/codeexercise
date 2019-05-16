using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Algorthims
{
    class Program
    {
        static void Main(string[] args)
        {
            var arr = new int[3][];
            arr[0] = new int[] { 4, 9, 2 };
            arr[1] = new int[] { 3, 5, 7 };
            arr[2] = new int[] { 8, 1, 5 };

            arr[0] = new int[] { 4, 8, 2 };
            arr[1] = new int[] { 4, 5, 7 };
            arr[2] = new int[] { 6, 1, 6 };

            arr[0] = new int[] { 9, 2, 4 };
            arr[1] = new int[] { 7, 5, 3 };
            arr[2] = new int[] { 4, 8, 8 };



            var cost = formingMagicSquare(arr);
            Console.WriteLine(cost);
        }

        static int formingMagicSquare(int[][] s)
        {

            var possibles = new int[8][,];

            possibles[0] = new int[,] { { 8, 1, 6 }, { 3, 5, 7 }, { 4, 9, 2 } };
            possibles[1] = new int[,] { { 6, 1, 8 }, { 7, 5, 3 }, { 2, 9, 4 } };
            possibles[2] = new int[,] { { 4, 9, 2 }, { 3, 5, 7 }, { 8, 1, 6 } };
            possibles[3] = new int[,] { { 2, 9, 4 }, { 7, 5, 3 }, { 6, 1, 8 } };
            possibles[4] = new int[,] { { 8, 3, 4 }, { 1, 5, 9 }, { 6, 7, 2 } };
            possibles[5] = new int[,] { { 4, 3, 8 }, { 9, 5, 1 }, { 2, 7, 6 } };
            possibles[6] = new int[,] { { 6, 7, 2 }, { 1, 5, 9 }, { 8, 3, 4 } };
            possibles[7] = new int[,] { { 2, 7, 6 }, { 9, 5, 1 }, { 4, 3, 8 } };

            var cost = int.MaxValue;

            for(var i = 0; i< possibles.Length;i++){
                var arr = possibles[i];

                var totalCost = 0;
                for(var j = 0; j < 3;j ++){
                    for(var k = 0;k<3;k++){
                        totalCost += Math.Abs(s[j][k] - arr[j,k]);
                    }
                }

                if(totalCost<cost){
                    cost = totalCost;
                }

            }

            return cost;
        }
    }
}