using System;
using System.Linq;
using System.Collections.Generic;


namespace ConsoleApplication {
    /// <summary>
    /// 检查一个给后序遍历定序列是否为二叉查找树
    /// </summary>
    public class VerifyBstSequence : ITemplate
    {
        public void print()
        {
            var t1 = new int[]{5,7,6,9,11,10,8};
            var t2 = new int[]{7,4,6,5};
            System.Console.WriteLine(VerifySequence(t1, 0, t1.Length));
            System.Console.WriteLine(VerifySequence(t2, 0, t2.Length));
        }

        /// <summary>
        /// 校验seq[left, right)是否符合BST
        /// </summary>
        /// <param name="seq">完整数组</param>
        /// <param name="left">左闭边界</param>
        /// <param name="right">右开边界</param>
        /// <returns></returns>
        private bool VerifySequence(int[] seq, int left, int right){
            if(seq == null || right - left <= 0) return false;
            
            var root = seq[right - 1];
            
            // 找出左子树的最大index, lchildIndex 等于左子树最大地址+1, 即右子树开始的地址
            var lchildIndex = left;
            while(seq[lchildIndex] <= root && lchildIndex < right - 1)
                lchildIndex ++;

            // 如果右子树有小于root则返回false
            var rchildIndex = lchildIndex;
            while(rchildIndex < right - 1){
                if(seq[rchildIndex] < root) return false;
                rchildIndex ++;
            }

            // 格子检查左右子树, 
            // 如果右子树开始等于left, 说明没有左子树, 返回true, 右子树同理
            var vleft = lchildIndex > left ? VerifySequence(seq, left, lchildIndex) : true;
            var vright = lchildIndex < right - 1 ? VerifySequence(seq, lchildIndex, right - 1) : true;

            return vleft && vright;
        }
    }
}