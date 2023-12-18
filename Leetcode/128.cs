using System;
using System.Collections.Generic;

namespace ConsoleApplication
{
    public class Q128 : ITemplate
    {
        public void print()
        {
            var data = new []{0,3,7,2,5,8,4,6,0,1};
            System.Console.WriteLine(LongestConsecutiveSequence(data));
        }


        public int LongestConsecutiveSequence(int[] nums)
        {
            var dic = new Dictionary<int, int>();
            var maxLen = 0;

            foreach(var num in nums)
            {
                if(dic.ContainsKey(num))
                    continue;
                
                dic.TryGetValue(num - 1, out var left);
                dic.TryGetValue(num + 1, out var right);
                var curLen =  left + right + 1;

                dic.Add(num, curLen);
                dic[num - left] = curLen;
                dic[num - right] = curLen;

                maxLen = Math.Max(maxLen, curLen);
            }

            return maxLen;
        }
    }
}