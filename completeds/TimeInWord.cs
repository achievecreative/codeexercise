using System;

namespace Solutions
{
    public class Program{
        static string[] hours = new []{"one", "two", "three", "four","five","six","seven","eight","nine","ten","eleven","twelve","thirteen", "fourteen", "fifteen", "sixteen", "seventeen", "eighteen", "nineteen" };

        static string timeInWords(int h, int m) {
            
  if(m == 0){
                return $"{hours[h-1]} o' clock";
            }

            var middle = m > 30?"to":"past";
            var hour = m > 30?h:h-1;

             m = m > 30? (60 - m):m;

            var minutes = "";
            if(m == 30){
                minutes = "half";
            }else if(m == 15){
                minutes = "quarter";
            }
            else if(m < 20){
                minutes = hours[m-1] + (m==1?" minute":" minutes");
            }
            else{
                minutes = "twenty";

                var _m = m % 10;
                if(_m != 0){
                    minutes += " " + hours[_m-1];
                }
                
                minutes +=" minutes";
            }

            return $"{minutes} {middle} {hours[hour]}";
        }
    }
}