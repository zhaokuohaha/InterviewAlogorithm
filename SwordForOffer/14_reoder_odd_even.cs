// 移动一个数组， 将所有奇数放在偶数前面个

using System;

namespace ConsoleApplication{
    public class ReoderOddEven : ITemplate
    {
        public void print()
        {
            bool IsEven(int n) => (n&1) == 1;
            bool IsPositive(int n) => n > 0;
            var orderEven = ReorderArray(new []{8,5,1,2,9,4,51,6,9,6,9,8,4,75,6,9,1,2}, IsEven);
            var orderPositve = ReorderArray(new []{8,-5,1,2,-9,4,-51,6,-9,-6,9,-8,4,-75,6,-9,1,2}, IsPositive);

            System.Console.WriteLine("Order Event" + string.Join(",", orderEven));
            System.Console.WriteLine("Order Positive:" + string.Join(",", orderPositve));
        }

        /// <summary>
        /// 数组移动方法， 按照指定方法移动数组, 使用双指针实现
        /// </summary>
        /// <param name="arr"></param>
        /// <param name="func">移动方法， func = true 的数字移动到前面</param>
        /// <returns></returns>
        private int[] ReorderArray(int[] arr, Func<int, bool> func){
            if(arr.Length <= 1) return arr;
            int left = 0, right = arr.Length -1;
            while(left < right){
                while(func(arr[left])) left ++;
                while(!func(arr[right])) right --;
                if(right > left){
                    Swap(arr, left, right);
                }
            }
            return arr;
        }

        private void Swap(int[] arr, int left, int right)
        {
            var temp = arr[left];
            arr[left] = arr[right];
            arr[right] = temp;
        }
    }
}