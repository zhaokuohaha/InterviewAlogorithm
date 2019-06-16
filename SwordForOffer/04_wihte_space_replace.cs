// 手动实现空格替换

using System;
using System.Linq;

namespace ConsoleApplication {
    public class WhiteSpaceReplace : ITemplate
    {
        public void print()
        {
             char[] str = new char[]{' ','e',' ',' ','r','e',' ',' ','a',' ','p',' '};
             System.Console.WriteLine(Replace(str));
             System.Console.WriteLine(str);

            var val = new char[] {'1', '2', '3'};
            System.Console.WriteLine(test(val));
             System.Console.WriteLine(val);
        }

        public char[] test(char[] val){
            val[0] = '_';

            // 一个疑问：为什么resize后， val 与返回的val发生了变化
            // Array.Resize(ref val, 4);
            // val[3] = '_';
            return val;
        }

        // 算出新增的长度后从右往左填， 时间复杂度 O(n)
        public char[] Replace (char[] str){
            var len = str.Length;
            var spaceCount = str.Count(ch => ch.Equals(' '));
            var newLen = len + 2 * spaceCount;

            Array.Resize(ref str, newLen);
            var l = len -1;
            var r = newLen -1;
            while(r >= 0){
                if(str[l] == ' '){
                    str[r--] = '0';
                    str[r--] = '2';
                    str[r--] = '%';
                }else{
                    str[r--] = str[l];
                }
                l --;
            }
            return str;
        }
    }
}