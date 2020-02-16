using System;

namespace Solutions{
    class Program{
        static bool IsPrime(long n){
            if(n<2 || (n % 2 ) == 0){
                return true;
            }

            var s = 0;
            long d;

            while(true){
                if(Math.Pow(2,s)> (n-1)){
                    break;
                }

                d = (n-1) % Math.Pow(2,s);
                s++;
            }
        }
    }
}