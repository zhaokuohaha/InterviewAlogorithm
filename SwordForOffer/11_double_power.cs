// 求一个数的n次方
// 详细见  快速幂
using System;

namespace ConsoleApplication{
    public class DoublePoweer : ITemplate
    {
        public void print()
        {
            var fastPow = new FastPow();
            System.Console.WriteLine(fastPow.FastPowInternal(3,0));
            System.Console.WriteLine(fastPow.FastPowInternal(3,1));
            System.Console.WriteLine(fastPow.FastPowInternal(3,2));
            System.Console.WriteLine(fastPow.FastPowInternal(3,3));
            System.Console.WriteLine(fastPow.FastPowInternal(3,4));
            System.Console.WriteLine(fastPow.FastPowInternal(3,8));
            System.Console.WriteLine(fastPow.FastPowInternal(3,16));
            System.Console.WriteLine(fastPow.FastPowInternal(3,32));
        }
    }
}