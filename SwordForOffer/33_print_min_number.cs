using System;
using System.Linq;
using System.Collections.Generic;

namespace ConsoleApplication
{
    public class PrintMinNum : ITemplate
    {
        /// <summary>
        /// 输入一个正整数数组，把数组里所有数字拼接起来排成一个数，打印能拼接出的所有数字中最小的一个。例如输入数组{3，32，321}，则打印出这三个数字能排成的最小数字为321323。
        /// </summary>
        public void print()
        {
            System.Console.WriteLine(BuildMinNumber(new[] { 3, 32, 321 }));
        }

        // 思路是定义一个新的排序规则，比较两数大小，将数组中数字按从“小”到“大”顺序排好后用字符串连接起来得到的就是最小数字。
        // 排序规则如下：
        //      先将数字转化为字符串，然后拼接，如果ab < ba，则规定a < b，否则规定a > b。
        // 有了排序规则就可以使用快排将数组中数字进行排序，排好序后连接即可。
        private string BuildMinNumber(int[] arr)
        {
            var strArr = arr.Select(a => a.ToString()).ToArray();
            Array.Sort(strArr, cmp);
            return string.Join(string.Empty, strArr);
        }

        static int cmp(string x, string y)
        {
            return string.Compare(x + y, y + x);
        }
    }
}