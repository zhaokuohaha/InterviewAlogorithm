// 判断一个数二进制中1的个数

using System;

namespace ConsoleApplication {
    public class NumberOfOne : ITemplate
    {
        public void print()
        {
            System.Console.WriteLine(1);
            System.Console.WriteLine(CountOne((int)Math.Pow(2,2) -1));
            System.Console.WriteLine(CountOne((int)Math.Pow(2,3) -1));
            System.Console.WriteLine(CountOne((int)Math.Pow(2,4) -1));
            System.Console.WriteLine(CountOne((int)Math.Pow(2,5) -1));
            System.Console.WriteLine(CountOne((int)Math.Pow(2,6)));
            System.Console.WriteLine(CountOne((int)Math.Pow(2,7)));
        }

        private int CountOne(int n){
            int res = 0;
            while(n > 0){
                if((n & 1) == 1)
                    res ++;
                n >>= 1;
            }
            return res;
        }
    }
}