//东方财富笔试题:找出所有的回文子串

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