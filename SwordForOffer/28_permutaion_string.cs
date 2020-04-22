using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApplication
{
    /// <summary>
    /// 输入一个字符串， 输出字符串所有的排列
    /// 其实就是一个全排列问题
    /// 特殊情况： 如果两个数相同， 则全排列结果是一样的
    /// </summary>
    public class PermutionString : ITemplate
    {
        public void print()
        {
            var t = PremNotRecursion("1234");
            foreach (var s in t)
                System.Console.WriteLine(s);
        }

        // 非递归解法
        // 思路, 先取得最小的排列, 如 1234, 'abcd' 从小到大逐个排序, 实现办法:
        // 如何计算字符串的下一个排列了？来考虑"926520"这个字符串，我们从后向前找第一双相邻的递增数字，
        // "20"、"52"都是非递增的，"26 "即满足要求，称前一个数字2为替换数，替换数的下标称为替换点，
        // 再从后面找一个比替换数大的最小数（这个数必然存在），0、2都不行，5可以，将5和2交换得到"956220"，
        // 然后再将替换点后的字符串"6220"颠倒即得到"950226"。 
        // 这样便能找到比当前排列大的最小的排列
        // 循环以上步骤, 直到排列最大

        private IList<string> PremNotRecursion(string s)
        {
            var arr = s.OrderBy(c => c).ToList();
            var res = new List<string>();
            var isEnd = false;

            while (!isEnd)
            {
                var (left, right) = FindSwapPoint(arr);

                if (left < right)
                {
                    arr.Swap(left, right);
                    arr.Reverse(left + 1, right - left); // 翻转替换点之后的数据
                    res.Add(string.Join(string.Empty, arr));
                }
                else
                {
                    isEnd = true;
                }
            }

            return res;
        }

        // 找出需要交换的两个点, 分别是:
        // left: 替换点
        // right: 从后往前找第一个大于替换点的数所在的位置
        private (int l, int r) FindSwapPoint(IList<char> arr)
        {
            int l = arr.Count - 2, r = arr.Count - 1;
            while (l >= 0 && arr[l] >= arr[l + 1])
                l--;

            if (l < 0)
                return (l, l); ;

            while (r > 0 && arr[r] <= arr[l])
                r--;

            return (l, r);
        }
    }
}