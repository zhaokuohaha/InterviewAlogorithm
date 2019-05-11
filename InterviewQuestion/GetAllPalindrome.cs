/// <summary>
/// 东方财富笔试题:找出所有的回文子串
/// 分两种情况, 1. s[i] 为字串的中间， 2. s[i] = s[i+1] 字串关于二者之间堆成
/// 实现：遍历字符串， 分以上两种情况， 找出字串， 以第一中情况为例子：
/// 从位置 i 开始， 设置游标l, r 分别网左右查询， 直到 s[l] != s[r], 如果长度 > 1 则为有效字串 p
/// 如果已经找到的字串中不含 p ， 则 res.Add(p)
/// </summary>

using System;
using System.Collections.Generic;

namespace ConsoleApplication{
    public class GetAllPalindromeClass{
        public void print(){
            string input = "dfjfsdsfsfsfkasdfal;ajnck";
            List<string> res = GetAllPalindrome(input);
            foreach(string item in res)
            {
                Console.WriteLine(item);
            }
        }

        public List<string> GetAllPalindrome(string input)
        {
            List<string> res = new List<string>();
            for(int i=0; i<input.Length-1; i++)
            {
                Check(input, i, i, res);
                Check(input, i, i+1, res);
            }
            return res;
        }

        private void Check(string s, int l, int r, List<string> res)
        {
            if (s[l] != s[r]) return;
            while(l-1 >=0 && r+1 < s.Length && s[l-1] == s[r+1])
            {
                l--;
                r++;
            }
            if (r == l) return;
            string p = s.Substring(l, r - l + 1);
            if(!res.Contains(p))
                res.Add(p);
        }
    }
}