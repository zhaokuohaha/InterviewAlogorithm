// 输入某二叉树的前序遍历和中序遍历结果， 重建该二叉树
// 假设树没有重复节点
// 前序遍历： 根，左，右  ， 中序遍历： 左， 根， 右

using System;

namespace ConsoleApplication {
    public class ConstructBinaryTree : ITemplate
    {
        public void print()
        {
            var preorder = new [] {1,2,4,7,3,5,6,8};
            var inorder = new [] {4,7,2,1,5,3,8,6};

            var note = Contruct(preorder, inorder);
            note.PrintPreOrder();
        }

        /// <summary>
        /// 思路: 1. 先序遍历中， 第一个数（位置为l)是该（子）树的根节点， 
        ///       2. 找到对应中序遍历中该值的位置r， [l, r) 的为左子树，右边为右子树
        ///       3. 先序遍历中 (l, r] 位置为左子树， 后面为右子树， 分两部分递归步骤1
        /// </summary>
        /// <param name="preorder">先序遍历序列</param>
        /// <param name="inorder">中序遍历序列</param>
        /// <returns></returns>
        public TreeNode Contruct(int[] preorder, int[] inorder){
            if( preorder == null 
                || inorder == null 
                || preorder.Length != inorder.Length  
                || preorder.Length <= 0)
            {
              return null;  
            } 
            var l = 0;
            var r = preorder.Length -1;
            return ConstructCore (preorder, l, r, inorder, l, r);
        }

        public TreeNode ConstructCore(int[] preorder, int pl, int pr, int[] inorder, int il, int ir){
            if(pl > pr) return null;
            var root = new TreeNode(preorder[pl]);
            
            // 找到中序遍历的位置
            var iindex = il;
            while(iindex < ir && inorder[iindex] != root.val){
                iindex ++;
            }
            if(iindex > ir) throw new Exception("数据不正确， 中序遍历中没有找到对应的数据");

            // 先序遍历左子树的末尾位置： pl + 左子树长度
            var pLeftLen = pl + iindex - il;
            root.left = ConstructCore(preorder, pl+1, pLeftLen, inorder, il, iindex -1);
            root.right = ConstructCore(preorder, pLeftLen + 1,  pr, inorder, iindex+1, ir);

            return root;
        }

        
    }
}