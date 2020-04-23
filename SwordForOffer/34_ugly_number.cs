using System;
using System.Linq;

namespace ConsoleApplication
{
    /// <summary>
    /// 把只包含质因子2、3和5的数称作丑数（Ugly Number）。例如6、8都是丑数，但14不是，因为它包含质因子7。 
    /// 习惯上我们把1当做是第一个丑数。求按从小到大的顺序的第N个丑数。
    /// </summary>
    public class UglyNumber : ITemplate
    {
        public void print()
        {
            System.Console.WriteLine(GetUglyNumner(1));
            System.Console.WriteLine(GetUglyNumner(10));
            System.Console.WriteLine(GetUglyNumner(400));
            System.Console.WriteLine(GetUglyNumner(1500));
        }


        // 我们只求丑数，不要去管非丑数。
        // 每个丑数必然是由小于它的某个丑数乘以2，3或5得到的，这样我们把求得的丑数都保存下来，
        // 用之前的丑数分别乘以2，3，5，找出这三这种最小的并且大于当前最大丑数的值，即为下一个我们要求的丑数。
        // 这种方法用空间换时间，时间复杂度为O(n)。
        // 参考链接: https://weiweiblog.cn/getuglynumber_solution/
        private int GetUglyNumner(int index)
        {
            if (index <= 0) return 0;
            if (index == 1) return 1;

            int t2 = 0, t3 = 0, t5 = 0;
            int[] res = new int[index];
            res[0] = 1;

            foreach (var i in Enumerable.Range(1, index - 1))
            {
                res[i] = min(res[t2] * 2, res[t3] * 3, res[t5] * 5);

                // 最小的那个数的下标往后移一位, 即前两次计算为例
                // res[1] = min(2,3,5) => res = [1, 2], t2 = 1
                // res[2] = min(2*2, 3, 5) => res = [1,2,3], t3 = 1
                // res[3] = min(2*2, 3*2, 5) => res = [1, 2, 3, 4], t2 = 2 以此类推
                if (res[i] == res[t2] * 2) t2++;
                if (res[i] == res[t3] * 3) t3++;
                if (res[i] == res[t5] * 5) t5++;
            }
            return res[index - 1];

        }

        private int min(params int[] arr) => arr.Min();
    }
}