// 斐波那契数列

using System;

namespace ConsoleApplication {
    public class FibonacciDemo : ITemplate
    {
        public void print()
        {
            System.Console.WriteLine(FibonacciInLoop(1));
            System.Console.WriteLine(FibonacciInLoop(2));
            System.Console.WriteLine(FibonacciInLoop(3));
            System.Console.WriteLine(FibonacciInLoop(4));
            System.Console.WriteLine(FibonacciInLoop(10));

            System.Console.WriteLine(FinonacciInMatrix(1));
            System.Console.WriteLine(FinonacciInMatrix(2));
            System.Console.WriteLine(FinonacciInMatrix(3));
            System.Console.WriteLine(FinonacciInMatrix(4));
            System.Console.WriteLine(FinonacciInMatrix(10));
        }

        // 单词查询的办法， 时间O(n), 空间O(1)
        // 如果多次查询的话， 直接打表，空间O(n),  除第一次外时间O(1), 
        private long FibonacciInLoop (uint n){
            var res = new []{0, 1};
            if(n < 2) return res[n];

            long left = 0, right = 1, fib = 0;
            for(var i = 2; i <= n; i++){
                fib = left + right;
                left = right;
                right = fib;
            }
            return fib;
        }


        private long FinonacciInMatrix(uint n){
            if(n == 0) return 0;
            matrix res = new matrix(1, 0, 0, 1); // 单位矩阵
            matrix m = new matrix(1,1,1,0);
            // 使用快速幂， 将时间复杂度在O(log(n))
            while(n > 0){
                if ((n & 1) == 1) // 该位为1（奇数）， 算一次乘法
                    res = MultiMatrix(res, m);
                m = MultiMatrix(m, m);
                n >>= 1;
            }
            return res.b;
        }

        /// <summary>
        /// 矩阵乘法
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        private matrix MultiMatrix(matrix x, matrix y){
            var res = new matrix();
            res.a = x.a * y.a + x.b * y.c;
            res.b = x.a * y.b + x.b * y.d;
            res.c = x.c * y.a + x.d * y.c;
            res.d = x.c * y.b + x.d * y.d;
            return res;
        }
    }

    struct matrix {
        public int a; public int b;
        public int c; public int d;

        public matrix(int a, int b, int c, int d){
            this.a = a; this.b = b;
            this.c = c; this.d = d;
        }
    }
}