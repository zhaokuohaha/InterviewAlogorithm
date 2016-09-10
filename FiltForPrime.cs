using System;


namespace ConsoleApplication{
    ///筛法求素数
    public class FiltForPrime
    {
        public void print(int max = 100){
            bool[] res = main(max);
            for(int i=0; i<=max; i++)
                if(res[i])
                    Console.WriteLine(i);
        }

        public bool[] main(int max){
            bool[] flags = new bool[max + 1];
            for (int i = 2; i < flags.Length; i++)
            {
                flags[i] = true;
            }
            int prime = 2;
            while (prime <= max)
            {
                //划掉余下为prime的倍数的数字
                //可以从prime*prime开始划掉, 因为如果k*prime && k<prime 这个值在之前的迭代理就被划掉了
                for (int i = prime * prime; i < flags.Length; i += prime)
                    flags[i] = false;
                //获取下一个素数
                prime = GetNextPrime(flags, prime);
                if (prime >= flags.Length)
                    break;
            }
            return flags;
        }

        private int GetNextPrime(bool[] flags, int curprime)
        {
            int next = curprime + 1;
            while (next < flags.Length && !flags[next])
            {
                next++;
            }
            return next;
        }
    }
}
