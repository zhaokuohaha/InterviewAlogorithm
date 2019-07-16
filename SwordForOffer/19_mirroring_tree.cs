// 将一棵二叉树镜像

using System;

namespace ConsoleApplication {
    public class MirroringTree : ITemplate
    {
        public void print()
        {
            var constructor = new ConstructBinaryTree();
            var tree = constructor.Contruct(new []{8,81,9,2,4,7,71}, new []{9,81,4,2,7,8,71});
            tree.PrintPreOrder();
            MirrorRecursively(tree);
            tree.PrintPreOrder();
        }

        /// <summary>
        /// 常规实现比较简单， 只要递归一次交换就可以
        /// </summary>
        /// <param name="root"></param>
        private void MirrorRecursively (TreeNode root){
            if(root == null) return;
            if(root.left != null || root.right != null){
                var node = root.left;
                root.left = root.right;
                root.right = node;
            }

            MirrorRecursively(root.left);
            MirrorRecursively(root.right);
        }
    }
}