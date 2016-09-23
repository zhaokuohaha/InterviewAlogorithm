using System;

namespace ConsoleApplication
{
    public class QuitSortClass{
        public void print(){
            int[] array =  new int[]{9,8,7,6,5,4,3,2,1,0};
            QuitSort(array, 0, array.Length-1);
            foreach (int item in array)
            {
                Console.WriteLine(item);
            }
        }
        int count = 0;
        public  void QuitSort(int[] array, int left, int right){
            if(left >= right) return;
            //划分数组 --> 挖坑填数
            //以数组的中间值作为基准
            int index = MidStandartPartition(array, left, right);
            //以数组最左边值作为基准
            //int index = LeftStandartPartition(array, left, right);
            //分治
            QuitSort(array,left,index-1);
            QuitSort(array,index+1,right);
        }

        private int MidStandartPartition(int[] array, int left, int right){
            int l = left;
            int r = right;
            
            int index = (left+right) / 2;
            int temp = array[index];
            while(l < r){
                while(l < r && array[l] < temp)
                    l++;
                array[index] = array[l];
                index = l;
                while(l < r && array[r] > temp)
                    r--;
                array[index] = array[r];
                index=r;
            }
            array[index] = temp;
            return index;
        }

        private int LeftStandartPartition(int[] array, int left, int right){
            int temp = array[left];
            while(left < right){
                while(left < right && array[right] > temp)
                    right--;
                array[left] = array[right];
                while(left < right && array[left] <= temp)
                    left++;
                array[right] = array[left];
            }
            array[left] = temp;
            return temp;
        }

    }
}