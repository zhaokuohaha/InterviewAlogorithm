using System;

namespace ConsoleApplication
{
    public class JosephClass
    {
        public void print(){
            Console.WriteLine("Please Input n, k");
            int n = int.Parse(Console.ReadLine());
            int k = int.Parse(Console.ReadLine());
            Console.WriteLine("The winner is : "+Joseph(n,k));
            Console.WriteLine("If want No.0 win, should start from No: "+LastJoseph(n,k));
        }

// 经典约瑟夫环问题， 从第一位开始数， 第k个出去， 一共有n个人
        public int Joseph(int n,int k){
            if(n <= 1) return 0;
            return (Joseph(n-1,k)+k)%n;
        }
//应用类约瑟夫环问题：从第m为开始数， 要求的1位最后，第k个出去，一共n个人, 求m
        public int LastJoseph(int n, int k){
            return (n-Joseph(n,k))%n;
        }            
    }
}