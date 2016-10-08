using System;

namespace ConsoleApplication
{
    public class GCDClass
    {
        public void print(){
            Console.WriteLine(BitGCD(18,12)+"---"+TradionGCD(18,12));
            Console.WriteLine(BitGCD(33,12)+"---"+TradionGCD(33,12));
            Console.WriteLine(BitGCD(13,12)+"---"+TradionGCD(13,12));
            Console.WriteLine(BitGCD(1000,12)+"---"+TradionGCD(1000,12));
            Console.WriteLine(BitGCD(999,2)+"---"+TradionGCD(999,2));
        }


        //传统辗转相除法
        public int TradionGCD(int a, int b){
            if(a < b) 
                return TradionGCD(b,a);
            while(b > 0){
                int t = a%b;
                a=b;
                b=t;
            }
            return a;
        }
        /*
        利用位移运算的高效性:
        当a和b均为偶数，gcb(a,b) = 2*gcb(a/2, b/2) = 2*gcb(a>>1, b>>1)
        当a为偶数，b为奇数，gcb(a,b) = gcb(a/2, b) = gcb(a>>1, b)
        当a为奇数，b为偶数，gcb(a,b) = gcb(a, b/2) = gcb(a, b>>1)
        当a和b均为奇数，利用更相减损术运算一次，gcb(a,b) = gcb(b, a-b)
        */
        public int BitGCD(int a, int b){
            if(a == b) 
                return a;
            if(a < b) 
                return BitGCD(b,a);
            if((a&1)==0 && (b&1)==0)//都是偶数
                return BitGCD(a >> 1, b >> 1) << 1;
            else if((a&1)==0)//a是偶数
                return BitGCD(a >> 1, b);
            else if((b&1)==0)//b是偶数
                return BitGCD(a, b >> 1);
            else 
                return BitGCD(a-b, b);
        }
    }
}