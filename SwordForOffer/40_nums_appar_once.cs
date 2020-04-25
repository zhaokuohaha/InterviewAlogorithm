using System;

namespace ConsoleApplication
{
    /// <summary>
    /// 一个整形数组里除了两个数字之外, 其他数字都出现了两次, 请写出这两只只出现一次的数字
    /// 要求时间复杂度是O(n) 空间复杂度是O(1)
    /// </summary>
    public class NumApparOnce : ITemplate
    {
        public void print()
        {
            System.Console.WriteLine(FindNumApparOnce(new int[] { 2, 4, 3, 6, 3, 2, 5, 5 }));
        }

        // 思路: 本以为挺简单, 没想到挺难的.  消消乐的方法行不通, 不满足空间复杂度O(1)的要求.
        // 需要用到亦或运算的两个结论: 1. 两个相同的数亦或之后等于零 2. 一个数和0亦或还是它本身
        //      扩展结论: 在题目给出的数组, 每个依次亦或之后等于两个不同的数亦或的结果 (因为其他都消掉了)
        // 所以思路如下:
        //  1. 将数组中所有数亦或, 不同数的亦或结果 xor, xor 必定不为0, 即二进制至少有一位为1
        //  2. 在xor中找出第一个为1的二进制位, 那么这两个数在这一位上必定一个是0, 一个是1 假设为a, b
        //  3. 继续重复第一步操作, 不过有点变动:
        //      3.1 在这一位上为0的数依次亦或, 结果存到 res[0] 中, 
        //         因为此时一定不包括b, 并且包括的数中除了a, 剩下的一定两两相同, 所以亦或的结果就是 a
        //      3.2 同样的办法, 这一位为1的数进行亦或, 结果为b
        private (int a, int b) FindNumApparOnce(int[] arr)
        {
            // 找出亦或结果
            var xor = 0;
            foreach (var item in arr)
                xor ^= item;

            if (xor == 0)
                throw new Exception("全部一样");
            // 找出a,b二进制第一个不一样的位 (即亦或结果为1的)
            var index = FindFirstBitOne(xor);

            // 分类亦或
            var res = new int[2];
            foreach (var item in arr)
            {
                if (IsBitOne(item, index))
                    res[0] ^= item;
                else
                    res[1] ^= item;
            }

            return (res[0], res[1]);
        }

        private int FindFirstBitOne(int val)
        {
            var index = 0;
            while ((val & 1) == 0)
            {
                val >>= 1;
                index++;
            }

            return index;
        }

        private bool IsBitOne(int val, int index) => ((val >> index) & 1) == 0;

    }
}