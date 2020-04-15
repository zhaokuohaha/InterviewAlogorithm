using System;

namespace ConsoleApplication
{
    /// <summary>
    /// 输入一棵二叉搜索树，将该二叉搜索树转换成一个排序的双向链表。要求不能创建任何新的结点，只能调整树中结点指针的指向。
    /// </summary>
    public class BstToLinkList : ITemplate
    {
        public void print()
        {
            test01();
        }

        private TreeNode Convert(TreeNode pRoot)
        {
            if (pRoot == null)
                return null;
            var lastNode = new TreeNode[1];
            ConvertRecursion(pRoot, lastNode);
            var head = lastNode[0];
            while (head != null && head.left != null)
            {
                head = head.left;
            }
            return head;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pRoot">当前的根结点</param>
        /// <param name="lastNode">已经处理好的双向链表的尾结点</param>
        private void ConvertRecursion(TreeNode pRoot, TreeNode[] lastNode)
        {
            if (pRoot == null)
                return;
            var curNode = pRoot;

            // 递归左子树
            if (curNode.left != null)
            {
                ConvertRecursion(curNode.left, lastNode);
            }

            // 将当前结点的前驱指向已经处理好的双向链表（由当前结点的左子树构成）的尾结点
            curNode.left = lastNode[0];
            // 如果左子树转换成的双向链表不为空，设置尾结点的后继
            if (lastNode[0] != null)
            {
                lastNode[0].right = curNode;
            }

            // 记录当前结点为尾结点
            lastNode[0] = curNode;

            if (curNode.right != null)
            {
                ConvertRecursion(curNode.right, lastNode);
            }
        }


        //            10
        //         /     \
        //        6        14
        //       /\        /\
        //      4  8     12  16
        private void test01()
        {
            TreeNode node10 = new TreeNode(10);
            TreeNode node6 = new TreeNode(6);
            TreeNode node14 = new TreeNode(14);
            TreeNode node4 = new TreeNode(4);
            TreeNode node8 = new TreeNode(8);
            TreeNode node12 = new TreeNode(12);
            TreeNode node16 = new TreeNode(16);
            node16.val = 16;

            node10.left = node6;
            node10.right = node14;

            node6.left = node4;
            node6.right = node8;

            node14.left = node12;
            node14.right = node16;

            Console.Write("Before convert: ");
            printTree(node10);
            Console.WriteLine("null");

            TreeNode head = Convert(node10);

            Console.Write("After convert : ");
            printList(head);
        }

        private void printTree(TreeNode root)
        {
            if (root != null)
            {
                printTree(root.left);
                Console.Write(root.val + "→");
                printTree(root.right);
            }
        }

        private void printList(TreeNode head)
        {
            while (head != null)
            {
                Console.Write(head.val + "⇄");
                head = head.right;
            }

            System.Console.WriteLine("null");
        }
    }
}