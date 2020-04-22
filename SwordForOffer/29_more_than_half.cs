using System;

namespace ConsoleApplication
{

    /// <summary>
    /// 找出数组中出现次数超过半数的数字, 
    /// 约定: 为了方便, 若找不到该数返回 -1 (即数组中没有-1这个数, 实际要转变这个条件)
    /// </summary>
    public class MoreThanHalf : ITemplate
    {
        public void print()
        {
            var t1 = new int[][]{
                new int[]{1,1,3,4,1},
                new int[]{1,2},
                new int[]{1,1},
                new int[]{1,1,22,3,4}
            };
            foreach (var arr in t1)
            {
                var str = $"({string.Join(',', arr)})";
                System.Console.WriteLine($"{str}: {FindMoreThanHalfNum(arr)}");
            }
        }


        // 思路: 类似消消乐, 把每次遇到不同数字消掉, 剩下的就是出现次数最多的数字
        //      最后只要判断该数字是否超过半数即可
        private int FindMoreThanHalfNum(int[] arr)
        {
            if (arr == null || arr.Length <= 0)
                return -1;

            int res = -1;
            int times = 0;

            foreach (var num in arr)
            {
                if (times == 0)
                {
                    res = num;
                    times = 1;
                }
                else if (num == res)
                    times++;
                else
                    times--;
            }

            return CheckMoreThanHalf(arr, res);
        }

        // 检查是否超过半数, 如未超过则表示无超过半数的值
        private int CheckMoreThanHalf(int[] arr, int val)
        {
            var count = 0;
            foreach (var i in arr)
                count += i == val ? 1 : 0;
            return count * 2 > arr.Length ? val : -1;
        }
    }
}