//https://www.hackerrank.com/challenges/climbing-the-leaderboard/problem
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;


namespace Solutions{

    class Program{
        static int[] climbingLeaderboard(int[] scores, int[] alice) {
            var array = (new HashSet<int>(scores)).ToArray(); //remove duplicated
            var positions = new int[alice.Length];

            for(var i = 0; i < alice.Length; i ++){
                positions[i] = findPosition(array, alice[i], 0, array.Length-1) + 1;
            }

            return positions;
        }

        static int findPosition(int[] array, int score, int startIndex, int endIndex){
            if(startIndex >= endIndex){
                if(array[startIndex] == score){
                    return startIndex;
                }
                else if(array[startIndex] > score){
                    return startIndex + 1;
                }
                else{
                    return Math.Max(startIndex, 0);
                }
            }

            var middle = (startIndex + endIndex) / 2;
            if(array[middle] == score){
                return middle;
            }

            if(array[middle] > score){
                return findPosition(array, score, middle+1, endIndex);
            }

            return findPosition(array, score, startIndex, middle - 1);
        }

        static void Main(string[] args){
            var scores = new int[]{100, 100, 50, 40, 40, 20, 10};

            var alices = new int[]{5,25,50,120};

            var positions = climbingLeaderboard(scores, alices);

            Console.WriteLine(string.Join(" ", positions));
        }

    }
}