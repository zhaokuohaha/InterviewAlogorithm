using System;

namespace ConsoleApplication
{
    public class TreeNode{
        public int val{get;set;}
        public TreeNode left{get;set;}
        public TreeNode right{get;set;}

        public  TreeNode(int value){
            this.val = value;
        }
    }
}