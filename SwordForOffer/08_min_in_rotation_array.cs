// 在一个递增的旋转数组中查找最小的数

using System;

namespace ConsoleApplication {
    public class MinInRotationArray : ITemplate
    {

        public void print()
        {
            System.Console.WriteLine(Find(new int[]{1}));
            System.Console.WriteLine(Find(new int[]{1,2,3,4,5,6}));
            System.Console.WriteLine(Find(new int[]{3,4,5,6,1,2}));
            System.Console.WriteLine(Find(new int[]{4,5,6,1,2,3}));
            System.Console.WriteLine(Find(new int[]{3,3,3,3,3,3,3,4,5,6,1,2,3}));
        }

        private int Find(int[] arr){
            if (arr == null || arr.Length <= 0){
                throw new ArgumentException();
            }

            var l = 0;
            var r = arr.Length - 1;
            var mid = l;
            while(arr[l] >= arr[r]){
                if(r - l == 1){
                    mid = r;
                    break;
                }
                
                mid = (l+r)/2;

                if(arr[l] == arr[r] && arr[l] == arr[mid]) // 类似于 1， 1，1，0，1
                    return FindByOrder(arr, l, r);
                if(arr[l] <= arr[mid]) // mid 在递增序列内， 查右半边
                    l = mid;
                else if (arr[r] >= arr[mid]) // mid 在落差序列内， 查左半边
                    r = mid;
            }
            return arr[mid];
        }

        public int FindByOrder(int[] arr, int left, int right){
            System.Console.Write("find in order: ");
            for(var i = left + 1; i < right; i ++){
                if(arr[i] < arr[i-1])
                    return arr[i];
            }
            return arr[left];
        }
    }
}