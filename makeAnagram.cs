//https://www.hackerrank.com/challenges/ctci-making-anagrams/problem

using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace Algorithms{
    class Program{

        static int makeAnagram(string a, string b) {
            var dict = new Dictionary<char, int>();

            foreach(var c in a){
                if(dict.ContainsKey(c)){
                    dict[c]++;
                }
                else{
                    dict.Add(c, 1);
                }
            }

            var totalToRemove = 0;

            foreach(var c in b){
                if(dict.ContainsKey(c)){
                    var count = dict[c];
                    if(count > 0){
                        dict[c]--;
                    }
                    else{
                        totalToRemove++;
                    }
                }
                else{
                    totalToRemove++;
                }
            }

            return totalToRemove + dict.Where(x=>x.Value != 0).Sum(x=>x.Value);
        }
    }

}