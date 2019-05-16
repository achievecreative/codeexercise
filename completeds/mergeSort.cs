using System;
using System.ComponentModel.Design;

namespace Algorithms{
    class Program{
        static void Main(string[] args){
            var array = new int[]{1,6,9,3,4,9,10,2,5,6,11,90,1000,0,8,7};
            var temp = new int[array.Length];

            Sort(array, temp, 0, array.Length-1);
            
            Console.WriteLine(string.Join(" ", array));
        }

        static void Sort(int[] array, int[] temp, int left, int right){
            if(left>=right){
                return;
            }

            var middle = (left + right) / 2;
            Sort(array, temp, left, middle);
            Sort(array, temp, middle+1, right);
            Merge(array, temp, left, right);
        }

        static void Merge(int[] array, int[] temp, int left, int right){
            var middle = (left + right) / 2;
            var index = left;
            var leftStart = left;
            var leftEnd = middle;
            var rightStart = middle +1;

            while(leftStart <= leftEnd && rightStart <= right){
                if(array[leftStart] < array[rightStart]){
                    temp[index] = array[leftStart];
                    leftStart++;
                }else if(array[leftStart] > array[rightStart]){
                    temp[index] = array[rightStart];
                    rightStart++;
                }
                else
                {
                    temp[index] = array[leftStart];
                    leftStart++;
                    index++;
                    temp[index] = array[rightStart];
                    rightStart++;
                }
                index++;
            }

            if(leftStart<=leftEnd){
                for(var i = leftStart; i<= leftEnd;i++){
                    temp[index] = array[i];
                    index++;
                }
            }

            if(rightStart <= right){
                for(var i = rightStart; i<= right; i++){
                    temp[index] = array[i];
                    index++;
                }
            }

            //copy temp to array

            for(var i = left; i<=right;i++){
                array[i] = temp[i];
            }
        }
    }

}