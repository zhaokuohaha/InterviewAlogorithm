using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApplication
{
    /// <summary>
    /// n个骰子点数之和为s, 输入n, 求所有s的可能只及其概率
    /// </summary>
    public class DiceSum : ITemplate
    {
        public void print()
        {
            var res = GetDiceSum(10);
            foreach (var item in res)
            {
                System.Console.WriteLine($"值:{item.sum} 数量:{item.count}");
            }
        }

        private (int sum, int count)[] GetDiceSum(int n)
        {
            var maxs = n * 6;
            var dp = new int[n + 1, maxs + 1];
            foreach (var sum in Enumerable.Range(1, 6))
                dp[1, sum] = 1;

            // 理论上可以用两个一维数组完成, 为了方便理解, 还是使用二维数组
            for (var k = 2; k <= n; k++)
            {
                maxs = k * 6;
                for (var sum = k; sum <= maxs; sum++)
                {
                    foreach (var i in Enumerable.Range(1, 6))
                        dp[k, sum] += getDP(k - 1, sum - i);
                }
            }

            // 将结果复制到返回值中
            // 最小 n, 最大 maxs, 可能的值的数量
            var sumNum = maxs - n + 1;
            var res = new (int, int)[sumNum];
            var index = 0;
            foreach (var sum in Enumerable.Range(n, sumNum))
            {
                res[index++] = (sum, dp[n, sum]);
            }

            return res;

            int getDP(int _n, int _s) => _s < 0 || _n < 0 ? 0 : dp[_n, _s];
        }
    }

    internal class Dice
    {
        public int Sum { get; set; }
        public int Count { get; set; }

        Dice(int s, int c)
        {

        }
    }
}