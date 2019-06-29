// 输入n, 打印出从1到最大的n位数。 如输入3， 则输出1-999
// 此题主要考虑大数问题， 所以用数组模拟实现

using System;

namespace ConsoleApplication{
    public class MaxNDigits : ITemplate
    {
        public void print()
        {
            PrintOneToNthDigits(2);
        }

        private void PrintOneToNthDigits(int n){
            if(n < 1) throw new ArgumentException("the input number must larger then 0");
            int [] arr = new int[n];
            while(AddOne(arr)){
                System.Console.WriteLine(string.Concat(arr).TrimStart('0'));
            }
        }

        /// <summary>
        /// 对 arr 表示的数组最低为加1
        /// </summary>
        /// <param name="arr"></param>
        /// <returns>如果最高位溢出， 则返回1</returns>
        private bool AddOne(int[] arr){
            int carry = 1;
            int index = arr.Length-1;
            while(carry != 0 && index >= 0){
                arr[index] += carry;
                carry = arr[index] / 10;
                arr[index] %= 10;
                index --;
            }
            return carry == 0;
        }
    }
}