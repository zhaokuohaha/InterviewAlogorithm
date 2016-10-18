using System;

namespace ConsoleApplication
{
    public class ReConstructBinaryTreeClass{
        public void print(){

        }

        public TreeNode ReConstructBinaryTree(int[] pre, int[] tin){
            if(pre.Length <= 0) return null;
            return MakeNode(pre, tin, 0, pre.Length-1, 0, tin.Length-1);
        }
        
        private TreeNode MakeNode(int[] pre, int[]tin, int startPre, int endPre, int startTin, int endTin){
            if(startPre > endPre || startTin > endTin)
                return null;
            int rootVal = pre[startPre];
            TreeNode root = new TreeNode(rootVal);

            if(startPre == endPre) 
                return root;
            int rootTin = startTin;//根节点在中序序列中的位置
            while(rootTin <= endTin && tin[rootTin] != rootVal){
                rootTin++;
            }
            int leftPreEnd = startPre + rootTin - startTin;//左子树的结束相当于 start + 左子树长度
            root.left = MakeNode(pre,tin,     startPre+1,  leftPreEnd,    startTin, rootTin-1);
            root.right = MakeNode(pre,tin,    leftPreEnd+1,endPre,        rootTin+1,endTin);
            return root;
        }
    }
}