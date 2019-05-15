using System;

namespace Algorithms{
    class Program{
        static long substrCount(int n, string s) {
            long total = 0;

            for(var i = 0; i<n;i++){
                total++;
                var left = i-1;
                var right = i+1;

                while(right < n){
                    if(s[right] == s[i]){
                        total++;
                        right++;
                    }
                    else{
                        break;
                    }
                }

                right = i+1;
                if(right>=n || s[right] == s[i]){
                    continue;
                }

                while(left>=0 && right < n){
                    if(s[left] == s[right]){
                        total++;

                        left--;
                        right++;
                    }
                    else{
                        break;
                    }
                }
            }

            return total;
        }

        static void Main(string[] args){
           // var r = substrCount(4, "aaaa");
            //Console.WriteLine(r);

            var r = substrCount(7, "abcbaba");
            Console.WriteLine(r);

            //r = substrCount(5, "asasd");
            Console.WriteLine(r);
        }
    }
}