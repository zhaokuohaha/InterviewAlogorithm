//东财笔试题2 -- 最长不重复字串

using System;
using System.Collections.Generic;

namespace ConsoleApplication
{
    public class LongestUndupClass  
    {
        public void print(){
            string input = "abcddfgss";
            Console.WriteLine(Longest(input));
            Console.WriteLine(Longest2(input));
        }

        public string Longest(string input)
        {
            int[] vis = new int[256];
            for (int i = 0; i < 256; i++) 
                vis[i] = -1;
            int n = input.Length;
            int maxlen = 0;
            vis[input[0]] = 0;
            int curlen = 1;
            int last_start = 0;
            int begin=0;
            for(int i=1; i<n; i++)
            {
                int a = input[i];
                if(vis[a] == -1)
                {
                    curlen++;
                    vis[a] = i;
                }else
                {
                    if(last_start <= vis[input[i]])
                    {
                        curlen = i - vis[a];
                        last_start = vis[a]+1;
                        vis[a] = i;
                    }else { curlen++; }
                }

                if(curlen > maxlen)
                {
                    maxlen = curlen;
                    begin = i + 1 - maxlen;
                }
            }
            return input.Substring(begin, maxlen);
        }
        public string Longest2(string input)
        {
            int start = 0;
            int length = input.Length;
            int maxlen = 0;
            for (int i = 0; i < input.Length; i++)
            {
                Dictionary<char, int> vis = new Dictionary<char, int>();
                char a = input[i];
                vis.Add(a,1);
                for(int j=i+1; j<input.Length; j++)
                {
                    char b = input[j];
                    if (!vis.ContainsKey(b))
                    {

                        vis.Add(b,1);
                        if (j - i + 1 > maxlen)
                        {
                            maxlen = j - i + 1;
                            start = i;
                        }
                    }
                    else break;
                }
            }
            return input.Substring(start, maxlen);
        }
    }
}