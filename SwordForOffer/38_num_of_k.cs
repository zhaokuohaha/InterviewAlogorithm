using System;

namespace ConsoleApplication
{
    /// <summary>
    /// 给定一个排序好的数组arr和数字k, 求数组中k的个数
    /// </summary>
    public class NumOfK : ITemplate
    {

        public void print()
        {
            System.Console.WriteLine(GetNumOfK(new int[] { 1, 2, 3, 3, 3, 3, 4, 5 }, 3));
        }

        // 思路: 分别用二分法找出第一个k和最后一个k
        private int GetNumOfK(int[] arr, int k)
        {
            if (arr == null || arr.Length <= 0)
                return -1;

            var first = GetFirstK(arr, k, 0, arr.Length - 1);
            var last = GetLastK(arr, k, 0, arr.Length - 1);

            if (first > -1 && last > -1)
                return last - first + 1;

            return 0;
        }

        private int GetFirstK(int[] arr, int k, int start, int end)
        {
            if (start > end) return -1;

            var mid = (start + end) / 2;
            var midVal = arr[mid];

            if (midVal > k)
            {
                end = mid - 1;
            }
            else if (midVal < k)
            {
                start = mid + 1;
            }
            else
            {
                if (mid == 0 || arr[mid - 1] != k) // 第一个k
                    return mid;
                end = mid - 1;  // 其前面还有k, 继续二分
            }

            return GetFirstK(arr, k, start, end);
        }

        private int GetLastK(int[] arr, int k, int start, int end)
        {
            if (start > end) return -1;

            var mid = (start + end) / 2;
            var midVal = arr[mid];

            if (midVal > k)
            {
                end = mid - 1;
            }
            else if (midVal < k)
            {
                start = mid + 1;
            }
            else
            {
                if (mid == arr.Length - 1 || arr[mid + 1] != k) // 最后一个k
                    return mid;
                start = mid + 1;  // 其后面面还有k, 继续二分
            }

            return GetLastK(arr, k, start, end);
        }
    }
}