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
            //挖坑
            int index = (left+right) / 2;
            int temp = array[index];
            while(l < r){
                while(l < r && array[l] < temp)
                    l++;
                array[index] = array[l];
                index = l;
                //这里不能 l++  为什么呢?
                //假设我带排序数组为  3 [1] 2
                //第一轮 : [3] 3 2 
                //如果 l++ ,此时 l = 1, 在下面的循环中, r = l = 1 时, 循环将中止, 然后替换, 数组变成 3 [3] 2 , 最后返回 3 [1] 2
                //而正确的算法应该是: l=0, 下面的循环中, r = l = 0 时, 循环将中止, 然后替换, 数组变成 [3] 3 2 , 最后返回 [1] 3 2  
                while(l < r && array[r] > temp)
                    r--;
                array[index] = array[r];
                index=r;
                //这里不能 r-- 跟上面 l++ 一个道理
            }
            //填坑
            array[index] = temp;
            return index;
        }

        private int LeftStandartPartition(int[] array, int left, int right){
            //挖坑
            int temp = array[left];

            while(left < right){
                //array[left] 是坑
                while(left < right && array[right] > temp)
                    right--;
                array[left] = array[right];                     //array[right] 是坑
                
                while(left < right && array[left] <= temp)
                    left++;
                array[right] = array[left];                     //array[left] 是坑 如此反复, 免了一步 赋值index的过程
                
            }
            //填坑   此时 坑 == left == right
            array[left] = temp;
            return temp;
        }

    }
}