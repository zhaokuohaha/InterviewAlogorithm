using System;
using System.Collections.Generic;

namespace ConsoleApplication
{
    /// <summary>
    ///  1.输入一个递增排序的数组和一个数字s, 在数组中查找两个数, 使得他们的和正好是s, 如果是多个, 则任意输出一个
    ///  2. 输入一个正数s, 打印出所有和为s的连续正数序列
    /// </summary>
    public class NumbersWithSum : ITemplate
    {
        public void print()
        {
            var arr = new[] { 1, 2, 4, 7, 11, 15 };
            System.Console.WriteLine(FindNumbersWithSum(arr, 15));

            var res = FindContinuousSeq(15);
            foreach (var (l, r) in res)
            {
                System.Console.WriteLine($"{l} ~ {r}");
            }
        }


        // 根据题目的意思, 因为数组已经排好序, 直接用双指针遍历即可
        private (int, int) FindNumbersWithSum(int[] arr, int sum)
        {
            if (arr == null || arr.Length < 2)
                return (-1, -1);

            int l = 0, r = arr.Length - 1;
            while (l < r)
            {
                int curSum = arr[l] + arr[r];
                if (curSum == sum)
                    return (arr[l], arr[r]);
                else if (curSum < sum)
                    l++;
                else
                    r--;
            }

            return (-1, -1);
        }

        // 这道题有数学解法, 比如利用等差数列公式(a + b)(b - a + 1) = 2 * sum; 
        // 这里还是使用模拟, 类似第一题的解法, 用双指针遍历.
        // 遍历终点为 left > 1+sum/2
        private List<(int, int)> FindContinuousSeq(int sum)
        {
            if (sum < 3) return null;
            var res = new List<(int, int)>();

            int left = 1;
            var right = left + 1;

            while (left <= sum / 2 + 1)
            {
                var curSum = (left + right) * (right - left + 1) / 2;
                while (curSum < sum)
                {
                    right++;
                    curSum = (left + right) * (right - left + 1) / 2;
                }
                if (curSum == sum)
                {
                    res.Add((left, right));
                }
                left++;
            }

            return res;
        }
    }
}