/// <summary>
/// 二分查找
/// 前台: 数组使有序的。
/// </summary>

using System;

namespace ConsoleApplication
{
    public class BinarySearchClass : ITemplate{
        public void print(){
            int[] array = new int[]{1,2,3,4,5,6,7,8,9};
            int index = BinarySearch(array, 3);
            Console.WriteLine(index +"---"+ array[index]);
        }

        public int BinarySearch(int []array, int x){
            int low = 0;
            int height = array.Length-1;
            int mid;
            while(low <= height){
                mid = (low+height)/2;
                if(array[mid] == x) return mid;
                if(array[mid] < x){
                    low = mid+1;
                }else{
                    height = mid-1;
                }
            }
            return -1;
        }
    }
}