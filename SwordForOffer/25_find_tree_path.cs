using System;
using System.Collections.Generic;

namespace ConsoleApplication
{
    public class FindTreePath : ITemplate
    {
        public void print() {
            var ctr = new ConstructBinaryTree();
            var tree = ctr.Contruct(new []{10, 5, 4, 7, 12}, new []{4, 5, 7, 10, 12});
            FindPath(tree, 22);
        }

        private void FindPath(TreeNode root, int expectSum){
            if(root == null) return;

            Stack<int> path = new Stack<int>();
            int curSum = 0;
            FindPath(root, expectSum, path, curSum);
        }

        private void FindPath(TreeNode node, int expectSum, Stack<int> path, int curSum)
        {
            curSum += node.val;
            path.Push(node.val);

            var isLeaf = node.left == null && node.right == null;
            if(isLeaf && curSum == expectSum){
                System.Console.WriteLine("a path is found: " + string.Join("->", path));
            } 

            if(node.left != null)
                FindPath(node.left, expectSum, path, curSum);
            if(node.right != null)
                FindPath(node.right, expectSum, path, curSum);

            curSum -= node.val;
            path.Pop();
        }
    }
}