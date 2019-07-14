using System;

namespace ConsoleApplication{
    public class HasSubTree : ITemplate
    {
        public void print()
        {
            // 此例只适用于没有重复节点的树
            // var constructor = new ConstructBinaryTree();
            // var parent = constructor.Contruct(new []{8,81,9,2,4,7,71}, new []{9,81,4,2,7,8,71});
            // var child = constructor.Contruct(new []{81,9,2}, new []{9,81,2});
            // System.Console.WriteLine(Check(parent, child));

            Test1();
        }

        private void Test1 (){
            var parent = new TreeNode(8);
            parent.left = new TreeNode(8);
            parent.left.left = new TreeNode(9);
            parent.left.right = new TreeNode(2);
            parent.left.right.left = new TreeNode(4);
            parent.left.right.right = new TreeNode(7);
            parent.right = new TreeNode(7);

            var child = new TreeNode(8);
            child.left = new TreeNode(9);
            child.right = new TreeNode(2);

            parent.PrintPreOrder();  
            parent.PrintInorder();
            child.PrintPreOrder();
            child.PrintInorder();
            System.Console.WriteLine(Check(parent, child));
            
        }

        private bool Check(TreeNode parent, TreeNode child){
            if(parent == null || child == null) return false;

            var res = false;
            if(parent.val == child.val)
                res = CompareSubTree(parent, child);
            if(!res) // 检查左子树
                res = Check(parent.left, child);
            if(!res) // 检查右子树
                res = Check(parent.right, child);
            
            return res;
        }

        private bool CompareSubTree(TreeNode parent, TreeNode child){
            // 先判断子树已经遍历完毕， 返回true, 如果子树未完成但是parent完成， 才是false
            if(child == null) return true;
            if(parent == null) return false;
            if(parent.val != child.val) return false;

            return CompareSubTree(parent.left, child.left) && CompareSubTree(parent.right, child.right); 
        }
    }
}