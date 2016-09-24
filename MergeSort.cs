using System;

namespace ConsoleApplication
{
    public class MergeSortClass{
        public void print(){
            int[] array =  new int[]{9,8,7,6,5,4,3,2,1,0};
            MergeSort(array,0,array.Length-1);
            foreach (int item in array)
            {
                Console.WriteLine(item);
            }
        }


        public void MergeSort(int[] arr, int left, int right){
            if(left < right){
                int mid = (left + right) / 2;
                MergeSort(arr, left, mid);
                MergeSort(arr, mid+1, right);
                MergeArray(arr, left, mid, right);
            }
        }

        private void MergeArray(int[] arr, int left, int mid, int right){
            int[] temp = new int[right-left+1];
            int j = 0;
            int l=left,m=mid+1,r=right;
            //为什么这里要令 m=mid+1, 因为当要归并的段只有两个数时, mid=left
            //这样的话,如果令 m=mid, 判断条件为 l<mid 的话, 下面这段循环便会跳过
            //此时如果arr[left] > arr[right], 直接跳到后面复制数组, 那么返回的数据将是错的
            //当然如果令 m=mid , 判断条件为 l <= mid 话更错, 因为arr[mid] 这个元素会被复制两次
            while(l <= mid && m <= right){
                if(arr[l] <= arr[m]){ //等于是保证排序的稳定性, 不会影响结果
                    temp[j++] = arr[l++];
                }else{
                    temp[j++] = arr[m++];
                }
            }
            while(l <= mid){
                temp[j++] = arr[l++];
            }
            while(m <= right){
                temp[j++] = arr[m++];
            }
            for(int i=0; i<j; i++){
                arr[left+i] = temp[i];
            }
        }
    }
}