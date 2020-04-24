using System;

namespace ConsoleApplication
{
    /// <summary>
    /// 在数组中的两个数字, 如果前面一个数字大于后面的数字, 则这两个数字组成一个逆序对
    /// 输入一个数组, 求出这个数组中的逆序对的总数
    /// </summary>
    public class InversePairs : ITemplate
    {
        public void print()
        {
            System.Console.WriteLine(CountInversePairs(new int[] { 1, 2, 3, 4, 5, 6, 7, 0 }));
        }

        private int CountInversePairs(int[] arr)
        {
            if (arr == null || arr.Length <= 0)
                return 0;
            return MergeSort(arr, 0, arr.Length - 1);
        }

        // 思路: 归并算法, 每相邻两项比较后排序,
        // 然后组合, 并继续比较相邻组合的逆序对, 然后排序.

        //例如7,5,4,6可以划分为两段7,5和4,6两个子数组
        // 在7,5中求出逆序对，因为7大于5所以有1对
        // 在6,4中求出逆序对，因为6大于4所以逆序对再加1，为2
        // 对7,5和6,4进行排序，结果为5,7,和4,6
        // 设置两个指针分别指向两个子数组中的最大值，p1指向7，p2指向6
        // 比较p1和p2指向的值，如果大于p2，因为p2指向的是最大值，所以第二个子数组中有几个元素就有几对逆序对(当前有两个元素，逆序对加2,2+2=4)，7>6,比较完之后将p1指向的值放入辅助数组里，辅助数组里现在有一个数字7，然后将p1向前移动一位指向5
        // 再次判断p1和p2指向的值，p1小于p2，因为p1指向的是第一个子数组中最大值，所以子数组中没有能和当前p2指向的6构成逆序对的数，将p2指向的值放入辅助数组，并向前移动一位指向4，此时辅助数组内为6,7
        // 继续判断p1(指向5)和p2(指向4)，5>4,第二个子数组中只有一个数字，逆序对加1，4+1=5，为5对，然后将5放入辅助数组，第一个子数组遍历完毕，只剩下第二个子数组，当前只有一个4，将4也放入辅助数组，函数结束。辅助数组此时为4,5,6,7.逆序对为5.
        // 参考: https://zhuanlan.zhihu.com/p/39811184
        private int MergeSort(int[] arr, int start, int end)
        {
            if (start == end) return 0;

            var mid = (start + end) / 2;
            var leftCount = MergeSort(arr, start, mid);
            var rightCount = MergeSort(arr, mid + 1, end);

            var sortedArr = new int[end - start + 1];
            int i = mid,
                j = end,
                index = end - start,   // 每次都是取最大值, 所以要从后往前填数组
                currCount = 0;
            while (i >= start && j >= mid + 1)
            {
                if (arr[i] > arr[j])
                { // 左边大于右边
                    currCount += j - mid;
                    sortedArr[index--] = arr[i--];
                }
                else
                {  // 右边大于左边, 不算逆序对
                    sortedArr[index--] = arr[j--];
                }
            }

            // 任一边空了之后, 直接填入未空的一边
            while (i >= start)
                sortedArr[index--] = arr[i--];
            while (j >= mid + 1)
                sortedArr[index--] = arr[j--];

            // 重新写回数组, 进行下一轮归并
            i = 0;
            while (start <= end)
                arr[start++] = sortedArr[i++];

            return currCount + leftCount + rightCount;
        }
    }
}