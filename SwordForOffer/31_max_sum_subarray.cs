using System;

namespace ConsoleApplication
{
    /// <summary>
    ///  输入一个数组, 数组里面有正数也有负数, 数组中一个或连续多个数字组成一个子数组
    /// 求所有子数组的和的最大值.
    /// 例如输入的数组为 1,-2,3,10,-4,7,2,-5 , 和最大值为 18 ,由子数组 3,10,-4,7,2 得出
    /// </summary>
    public class MaxSumSubArray : ITemplate
    {
        public void print()
        {
            var t = new int[] { 1, -2, 3, 10, -4, 7, 2, -5 };
            System.Console.WriteLine("最大子数组之和为: " + FindMaxSum(t));
        }

        // 实现:  一手简单的动态规划, 定义res[]数组
        // 假设 res[i] 为数组的前 i 项里面, 如果必须包含第 [i] 项的和的最大值
        // 则转移方程: res[i] = max(res[i-1] + arr[i], arr[i])
        // 最后只需求 res 数组里面最大的那个即可
        // 简化: res 数组可以简化成一个变量, 然后用一个 max 变量存储每次运算之后res的最大值
        private int FindMaxSum(int[] arr)
        {
            if (arr == null || arr.Length <= 0)
                return -1;

            var res = arr[0];
            var max = res;
            for (var i = 1; i < arr.Length; i++)
            {
                res = Math.Max(res + arr[i], arr[i]);
                max = Math.Max(res, max);
            }

            return max;
        }
    }
}