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

        /// <summary>
        /// 把一个整数减去1，再和原来的数进行与运算，会把该数最右边一个1变成0， 那么一个整数的二进制表示中又多少个1，就可以有多少次这样的操作
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        private int CountOne2(int n){
            int res = 0;
            while (n > 0){
                ++ res;
                n = (n-1) & n;
            }
            return res;
        }
    }
}