/// <summary>
/// 冒泡排序
/// </summary>
using System;

namespace ConsoleApplication{
    public class BubbleSortClass{
        public void print(){

        }

        public void Bubblesort(int[] arr){
            int temp;
            for(int outer = arr.Length-1; outer > 0; outer--){
                for(int inner = 0; inner <= outer; inner++){
                    if(arr[inner] > arr[inner+1]){
                        temp = arr[inner];
                        arr[inner] = arr[outer];
                        arr[outer] = temp;
                    }
                }
            }
        }
    }
}