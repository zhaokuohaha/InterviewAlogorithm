/*
翻转数字, 如输入123 返回 321 
坑点: 数字超出最大值时处理 => 本例返回0
思路:
    本例使用了最笨的方法, 一位一位转换, 应该有更快的方法
 */
using System;

namespace ConsoleApplication
{
    public class ReverseIntClass
    {
        public void print(){
            Console.WriteLine(ReverseInt(123));
            Console.WriteLine(ReverseInt(-1));
            Console.WriteLine(ReverseInt(-2346));
            Console.WriteLine(ReverseInt(2147483647));
            Console.WriteLine(ReverseInt(214748364));
        }
        private int ReverseInt(int x) {
        long res = 0;
        while(x != 0){
            res = (x % 10) + (res * 10);
            if(res > Int32.MaxValue || res < Int32.MinValue) return 0;
            x /= 10;
        }
        return (int)res;
    }
    }
}