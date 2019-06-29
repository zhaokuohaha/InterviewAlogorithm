/// <summary>
/// 快速幂， 在O(logn) 时间复杂度内求 m^n
/// 矩阵快速幂见 SwordForOffer > 09
/// </summary>

using System;

namespace ConsoleApplication {
    public class FastPow : ITemplate
    {
        public void print()
        {
            System.Console.WriteLine($"{FastPowInternal(10, 5)} - {Math.Pow(10, 5)}");
            System.Console.WriteLine($"{FastPowInternal(3, 9)} - {Math.Pow(3, 9)}");
            System.Console.WriteLine($"{FastPowInternal(6, 7)} - {Math.Pow(6, 7)}");
            System.Console.WriteLine($"{FastPowInternal(5, 12)} - {Math.Pow(5, 12)}");
            System.Console.WriteLine($"{FastPowInternal(34, 6)} - {Math.Pow(34, 6)}");
        }

        /// <summary>
        /// 5 ^ 12 = 5 ^ 1100
        /// 5*8 * 5*4 * 1 * 1
        /// </summary>
        /// <param name="m"></param>
        /// <param name="n"></param>
        /// <returns></returns> 
        private long FastPowInternal(long m, long n){
            long res = 1; // 2^0
            var bas = m; // 底数
            while(n > 0){
                if((n & 1) == 1){
                    res *= bas;
                }
                bas *= bas;
                n >>= 1;
            }
            return res;
        }
    }

}