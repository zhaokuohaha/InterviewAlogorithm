/// <summary>
/// 获取下一个全排列 --- 比当前数大的最小的数, 由下面4步组成
/// 如 123 -> 213 
/// </summary>

using System;
using System.Text;

namespace ConsoleApplication{
    public class NextPermutationClass{
        public void print(){
            Console.WriteLine(NextPermutation("1233"));
            Console.WriteLine(NextPermutation("4231"));
            Console.WriteLine(NextPermutation("abcd"));
        }

        public string NextPermutation(string cur){
            StringBuilder sb = new StringBuilder(cur);
            int len,pos,expos;
            len = pos = cur.Length-1;
            //1. 从右往左找到第一个波峰(pos), 即第一个递减的数
            while(pos > 0 && cur[pos] <= cur[pos-1]) pos--;
            if(pos==0) return "null";
            expos = pos;

            //2. 从波峰(pos)往右找到 比cur[pos-1] 大的最小数(expos)
            //FirstSwap(pos, expos+1) 保证这个区间内没有和expos+1一样的数, 也就是这是第一个符合要求的, 保证相同的数的全排列的正确性
            for(expos = len; expos < pos && sb[expos] <= sb[pos-1]; expos--);
            //3. 交换pos和expos的数
            char tmp = sb[pos-1];
            sb[pos-1] = sb[expos];
            sb[expos] = tmp;
            //pos后的数 按从小到大排列 ---> 
            for(int i=pos; i<len; i++){
                for(int j=i+1; j<=len; j++){
                    if(sb[i] > sb[j]){
                        tmp = sb[i];
                        sb[i] = sb[j];
                        sb[j] = tmp; 
                    }
                }
            }
            return sb.ToString();
        }
    }
}