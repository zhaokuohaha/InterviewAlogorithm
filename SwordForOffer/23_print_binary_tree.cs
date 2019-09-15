using System;
using System.Collections.Generic;

namespace ConsoleApplication {
    /// <summary>
    /// 按层级遍历从上到下打印一棵二叉树
    /// 用一个队列来完成
    /// </summary>
    public class PrintBinaryTree : ITemplate
    {
        public void print()
        {
            var ctr = new ConstructBinaryTree();
            var tree = ctr.Contruct(
                new int[] {8,6,5,7,10,9,11},
                new int[] {5,6,7,8,9,10,11}
            );
            // tree.PrintPreOrder();
            // tree.PrintInorder();
            
            PrintFromTopToBottom(tree);
        }

        private void PrintFromTopToBottom(TreeNode root){
            if(root == null) return;

            var deque = new Queue<TreeNode>();
            deque.Enqueue(root);

            while(deque.Count > 0){
                var pnode = deque.Dequeue();
                System.Console.Write($"{pnode.val} ");

                if(pnode.left != null)
                    deque.Enqueue(pnode.left);
                if(pnode.right != null)
                    deque.Enqueue(pnode.right);
            }
        }
    }
}