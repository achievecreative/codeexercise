//https://app.codility.com/programmers/lessons/3-time_complexity/tape_equilibrium/
//https://app.codility.com/demo/results/training6TJEUG-YJZ/


using System;
using System.Linq;
// you can also use other imports, for example:
// using System.Collections.Generic;

// you can write to stdout for debugging purposes, e.g.
// Console.WriteLine("this is a debug message");

class Solution {
    public int solution(int[] A) {
        // write your code in C# 6.0 with .NET 4.5 (Mono)
        long total = A.Sum();
        long diff = 0;
        
        for(var i=0;i<A.Length-1;i++){
            if(i==0){
                diff = Math.Abs(A[i] - (total - A[i]));
            }    
            else{
                A[i] = A[i] + A[i-1];
                long r =  Math.Abs(A[i] - (total - A[i]));
                if(r<diff){
                    diff = r;
                }
            }
        }
        
        return (int)diff;
    }
}
