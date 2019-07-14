using System;

namespace ConsoleApplication
{
    /// <summary>
    /// 二叉树结点
    /// </summary>
    public class TreeNode{
        public int val{get;set;}
        public TreeNode left{get;set;}
        public TreeNode right{get;set;}

        public  TreeNode(int value){
            this.val = value;
        }

        /// <summary>
        /// 先序遍历
        /// </summary>
        public void PrintPreOrder(){
            PreOrder(this);
            System.Console.WriteLine("END");
        }

        /// <summary>
        /// 中序遍历
        /// </summary>
        public void PrintInorder(){
            Inorder(this);
            System.Console.WriteLine("END");
        }
        private void PreOrder(TreeNode root) {
            if (root != null) {
                System.Console.Write(root.val + "-->");
                PreOrder(root.left);
                PreOrder(root.right);
            }
        }
        private void Inorder(TreeNode root){
            if (root != null) {
                Inorder(root.left);
                System.Console.Write(root.val + "-->");
                Inorder(root.right);
            }
        }
    }
}