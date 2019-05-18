/// <summary>
/// 约瑟夫环问题：
/// 问题描述: n个人（编号0~(n-1))，从0开始报数，报到(k-1)的退出，剩下的人继续从0开始报数。求胜利者的编号
/// 思路： 
///     作者：困瘦之斗
///链接：https://www.zhihu.com/question/20065611/answer/678995046
///来源：知乎
///递归问题分3步走：
/// 1、递归收敛：由于m是不变的，所以只能通过n将规模不断缩小
/// 2、找出口：当递归收敛到最小单位时，能得到一个出口。即当n=1时，出局者的位置为0
/// 3、找规律：分析已知条件，与我们需要结果的关联。
/// 
/// 因为我们已知最后一轮出局者在最后一轮中的位置，所以我们只需要找到后一轮出局者的位置，
/// 在上一轮中所处的位置，依次递归最终就能找到最后出局者在第一轮中的位置；
/// 我们知道第一轮出局者在本轮的位置(从0开始)为：f(n, m) = (m-1) % n且第二轮第0个位置在第一轮中的位置为：m % n（注：疑惑在链接文章中有详细解答）
/// ，第二轮第一个位置在第一轮中的位置为：(m+1) % n，
/// ...第二轮第k个位置在第一轮中的位置为：(m+k) % n；
/// 由此可推导出如下结论：
/// 第二轮出局者在第一轮中的位置为：f(n, m) = (f(n-1, m) + m) % n
/// 第三轮出局者在第二轮中的位置为：f(n-1, m) = (f(n-2, m) + m) % n...
/// 第n轮出局者在第n-1轮中的位置为: f(2, m) = (f(1, m) + m) % n
/// 
/// 根据步骤二，出口条件可得到：f(1, m) = 0
/// 根据递归性质，第二轮递归表达式即我们写递归函数需要用到的表达式，
/// 所以最终表达式为：f(n, m) = (f(n-1, m) + m) % n
/// 
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