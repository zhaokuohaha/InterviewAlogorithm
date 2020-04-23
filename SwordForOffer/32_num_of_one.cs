using System;
namespace ConsoleApplication
{
    /// <summary>
    /// 输入一个整数n，求从1到n这n个整数的十进制表示中1出现的次数。例如输入12，从1到12这些整数中包含1的数字有1,10,11和12，1一共出现了5次。
    /// </summary>
    public class NumOfOne : ITemplate
    {
        public void print()
        {
            System.Console.WriteLine(CountNumOfOne(31256));
            System.Console.WriteLine(CountNumOfOne(31156));
            System.Console.WriteLine(CountNumOfOne(31056));
        }
        // 先看任意一个5位数val, 统计其百位为1的个数(这里指只统计百位的1), 取 a=val/100, b=val%100 有以下几种情况:
        //  1.百位>=2的5位数字，其百位为1的情况有（a/10+1）*100个数字 
        //  2.百位为1的5位数字，共有（a/10）* 100 + (b+1) 个, 此时 a 的最后一位为 1
        //  3.百位数为0的5位数字，共有(a/10)*100个数字满足要求
        //  对于以上三步的推导, 可以看后面的注释


        //  4. 1,3 两种情况可以合并: ((a+8) / 10) * 100
        //  5. 2,4两种情况可以合并:  [(a+8)/10]*100 + (a%10==1) ? (b+1) : 0
        // 所以任一个5位数, 百位上为1的个数为: [(a+8)/10]*100 + (a%10==1) ? (b+1) : 0
        // 同样道理, 在十位上的个数统计, 取 a = val/10, b = val%10
        // 十位上为1的个数为: [(a+8)/10]*100 + (a%10==1) ? (b+1) : 0
        private int CountNumOfOne(int val)
        {
            var count = 0;
            for (int i = 1; i <= val; i *= 10)
            {
                count += (val / i + 8) / 10 + (val / i % 10 == 1 ? val % i : 0);
            }
            return count;
        }

        // 百位为1的推导过程:

        // 百位数字>=2  example: 31256  当其百位为>=时，有以下这些情况满足(为方便起见，计312为a，56为b)：
        // 100 ~   199
        // 1100 ~  1199
        // .....
        // 31100 ~ 31199
        // 余下的都不满足！
        // 因此，百位>=2的5位数字，其百位为1的情况有（a/10+1）*100个数字   （a/10+1）=>对应于 0 ~ 31，且每一个数字，对应范围是100个数（末尾0-99）

        // 百位数字 ==1 example: 31156 当其百位为1时，有以下这些情况满足：
        // 100 ~   199
        // 1100 ~  1199
        // ......
        // 30100 ~ 30199
        // 31100 ~ 31156
        // 因此，百位为1的5位数字，共有（a/10）*100+(b+1)

        // 百位数字 ==0 example: 31056 当其百位为0时，有以下这些情况满足：
        // 100 ~   199
        // 1100 ~  1199
        // 30100 ~ 30199
        // 其余都不满足

        // 参考链接: https://www.cnblogs.com/xuanxufeng/p/6854105.html
    }
}