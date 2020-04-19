using System;
using System.Linq;
using System.Text;

namespace ConsoleApplication
{
    /// <summary>
    /// 二叉树结点
    /// </summary>
    public class TreeNode
    {
        public int val { get; set; }
        public TreeNode left { get; set; }
        public TreeNode right { get; set; }

        public TreeNode(int value)
        {
            this.val = value;
        }

        /// <summary>
        /// 先序遍历
        /// </summary>
        public void PrintPreOrder()
        {
            PreOrder(this);
            System.Console.WriteLine("END");

            void PreOrder(TreeNode root)
            {
                if (root != null)
                {
                    System.Console.Write(root.val + "-->");
                    PreOrder(root.left);
                    PreOrder(root.right);
                }
            }
        }

        /// <summary>
        /// 中序遍历
        /// </summary>
        public void PrintInorder()
        {
            Inorder(this);
            System.Console.WriteLine("END");

            void Inorder(TreeNode root)
            {
                if (root != null)
                {
                    Inorder(root.left);
                    System.Console.Write(root.val + "-->");
                    Inorder(root.right);
                }
            }
        }

        private int Depth()
        {
            var lDepth = this.left?.Depth() ?? 0;
            var rDepth = this.right?.Depth() ?? 0;
            return Math.Max(lDepth, rDepth) + 1;
        }

        /// <summary>
        /// 按树形结构打印二叉树
        /// </summary>
        public void ShowTree()
        {
            var depth = Depth();

            var height = depth * 2 - 1; // 数组高度, 每层占两格
            var width = (2 << (depth - 2)) * 3 + 1; // 最后一行为 2^(n-1) * 3 + 1 作为整个数组的宽度
            var res = new string[height, width];
            for (var i = 0; i < res.GetLength(0); i++)
                for (var j = 0; j < res.GetLength(1); j++)
                    res[i, j] = " ";
            WriteArray(0, width / 2, res, depth);

            PrintArray(res);

        }

        private void WriteArray(int rowIndex, int colIndex, string[,] res, int treeDepth)
        {
            res[rowIndex, colIndex] = this.val.ToString();
            var curLevel = (int)Math.Ceiling((double)rowIndex / 2);
            var isLeaf = this.left == null && this.right == null;
            if (curLevel >= treeDepth || isLeaf)
                return;

            // 计算当前行到下一行每个元素之间的间隔
            var gap = treeDepth - curLevel - 1;

            if (this.left != null)
            {
                res[rowIndex + 1, colIndex - gap] = "/";
                this.left.WriteArray(rowIndex + 2, colIndex - 2 * gap, res, treeDepth);
            }

            if (this.right != null)
            {
                res[rowIndex + 1, colIndex + gap] = "\\";
                this.right.WriteArray(rowIndex + 2, colIndex + 2 * gap, res, treeDepth);
            }
        }

        private void PrintArray(string[,] res)
        {
            var sb = new StringBuilder();
            for (var i = 0; i < res.GetLength(0); i++)
            {
                for (var j = 0; j < res.GetLength(1); j++)
                    sb.Append(res[i, j]);
                sb.Append('\n');
            }
            System.Console.WriteLine(sb);
        }

    }
}