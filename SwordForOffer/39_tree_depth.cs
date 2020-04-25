using System;

namespace ConsoleApplication
{
    /// <summary>
    /// 1. 求二叉树深度, 2. 判断一棵树是否为平衡二叉树
    /// </summary>
    public class TreeDepth : ITemplate
    {
        public void print()
        {
            var ctr = new ConstructBinaryTree();
            var tree = ctr.Contruct(new[] { 10, 5, 4, 7, 12 }, new[] { 4, 5, 7, 10, 12 });
            tree.ShowTree();

            System.Console.WriteLine(GetTreeDepth(tree));
            System.Console.WriteLine(IsBalance(tree, out _));
        }

        // 求树高度, 遍历运算
        private int GetTreeDepth(TreeNode root)
        {
            if (root == null) return 0;

            var l = GetTreeDepth(root.left);
            var r = GetTreeDepth(root.right);

            return 1 + Math.Max(l, r);
        }

        // 判断是否为平衡二叉树, 遍历过程中价格标记即可
        private bool IsBalance(TreeNode root, out int depth)
        {
            if (root == null)
            {
                depth = 0;
                return true;
            }

            // 这里没有剪枝, 剪枝的话可以直接在判断左子树为false的时候直接返回false
            var islb = IsBalance(root.left, out var leftDepth);
            var isrb = IsBalance(root.right, out var rightDepth);
            var isBalance = Math.Abs(leftDepth - rightDepth) <= 1;

            depth = 1 + Math.Max(leftDepth, rightDepth);
            return isBalance;
        }
    }

}