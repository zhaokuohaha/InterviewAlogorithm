/// <summary>
/// 约瑟夫环问题：
/// 问题描述: n个人（编号0~(n-1))，从0开始报数，报到(k-1)的退出，剩下的人继续从0开始报数。求胜利者的编号
/// 思路： 
///     用递归求解, 如果只剩下一个人， 则为胜利者
///     否则， 将第k个剔除后， 求剩下n-1人的约瑟夫环问题
/// </summary>
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