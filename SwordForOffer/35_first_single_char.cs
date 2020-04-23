using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApplication
{
    /// <summary>
    /// 在字符串中找到第一个只出现一次的字符
    /// </summary>
    public class FirstSingleChar : ITemplate
    {
        public void print()
        {
            System.Console.WriteLine(GetFirstSingleChar("122345"));
            System.Console.WriteLine(GetFirstSingleChar("1122345"));
            System.Console.WriteLine(GetFirstSingleChar("11122"));
        }

        // 这个就简单了, 用一个Dictionary来存储各个字符串出现的次数即可
        // 实际上这也是实际开发中最常见的模式: 用构建字典来优化遍历的时间
        private char GetFirstSingleChar(string str)
        {
            if (str == null || str == string.Empty)
                return '-';
            var dict = new Dictionary<char, int>();
            foreach (var c in str)
            {
                if (!dict.ContainsKey(c))
                    dict.Add(c, 1);
                else
                    dict[c] += 1;
            }


            return dict.FirstOrDefault(kv => kv.Value == 1).Key;
        }
    }
}