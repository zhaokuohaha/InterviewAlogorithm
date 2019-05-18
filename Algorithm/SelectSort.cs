/// <summary>
///  先择排序算法
/// </summary>

using System;

namespace ConsoleApplication
{
    public class SelectSortClass
    {
        public void print(){

        }

        public void SelectSort(int[] arr){
            int min, temp;
            for(int outer = 0; outer < arr.Length-1; outer++){
                min = outer;
                for(int inner = outer+1; inner < arr.Length; inner++){
                    if(arr[inner] < arr[min]) 
                        min = 0;
                }
                temp = arr[outer];
                arr[outer] = arr[min];
                arr[min] = temp;
            }
        }
    }
}