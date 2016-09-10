using System;

namespace ConsoleApplication
{
    public class MergeSortClass{
        public void print(){
            int[] array =  new int[]{9,8,7,6,5,4,3,2,1};
            MergeSort(array,0,array.Length-1);
            foreach (int item in array)
            {
                Console.WriteLine(item);
            }
        }


        public void MergeSort(int[] array, int first, int end){
            if(first < end){
                int mid = (first+end)/2;
                MergeSort(array, first, mid);
                MergeSort(array, mid+1, end);
                MergeMethod(array, first, mid, end); //归并
            }
        }

        private void MergeMethod(int[] array, int first, int mid, int end){
            int[] helper = new int[array.Length];
            //copy需要排序的部分
            for(int i=first; i<=end; i++)
                helper[i] = array[i];
            int helperLeft = first;
            int helperRight = mid+1;
            int current = first;
            while (helperLeft <= mid && helperRight <= end)
            {
                if(helper[helperLeft] <= helper[helperRight]){
                    array[current++] = helper[helperLeft++];
                }else
                {
                    array[current++] = helper[helperRight++];
                }
            }
            int remaining = mid - helperLeft;
            for(int i=0; i<=remaining; i++){
                array[current+i] = helper[helperLeft+i];
            }
        }
    }
}