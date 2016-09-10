using System;

namespace ConsoleApplication
{
    public class QuitSortClass{
        public void print(){
            int[] array =  new int[]{9,8,7,6,5,4,3,2,1};
            QuitSort(array, 0, array.Length-1);
            foreach (int item in array)
            {
                Console.WriteLine(item);
            }
        }

        public  void QuitSort(int[] array, int left, int right){
            int index = Partition(array, left, right);
            if(left < index-1){
                QuitSort(array, left, index-1);
            }
            if(index < right){
                QuitSort(array, index, right);
            }
        }

        private int  Partition(int[] array, int left, int right){
            int privot = array[(left + right) / 2];//基准点
            while(left<=right){
                
                while(array[left] < privot) left++;
                while(array[right] > privot) right--;

                if(left<=right){
                    int temp = array[left];
                    array[left] = array[right];
                    array[right] = temp;
                    right--;
                    left++;
                }
            }
            return left;
        }
    }
}