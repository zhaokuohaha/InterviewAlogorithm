using System;

namespace ConsoleApplication{
    public class Node{
        public int Data;
        public Node left;
        public Node right;

        public Node(int i){
            this.Data = i;
        }
    } 
    public class BST{
        public Node root;
        public BST(){
            root = null;
        }

        public void print(){
            Insert(3);
            Insert(1);
            Insert(2);
            Insert(4);
            Insert(5);
            
            traversal(root);
        }

        private void traversal(Node node){
            if(node == null) return;
            Console.WriteLine("-->" + node.Data);
            traversal(node.left);
            traversal(node.right);
        }
        

        public void Insert(int i){
            if(root==null) root=new Node(i);
            else{
                Node cur = root;
                Node pre = cur;
                while(cur != null ){
                    pre = cur;
                    if(cur.Data < i){
                        cur = cur.right;
                    }else{
                        cur = cur.left;
                    }
                }

                if(i < pre.Data)
                    pre.left = new Node(i);
                else
                    pre.right = new Node(i);
            }
        }
    }
}