using System;

namespace ConsoleApplication{
    /// <summary>
    /// 链表节点 
    /// </summary>
    public class ListNode{
        public int val{get;set;}
        public ListNode next{get;set;}
        public ListNode(int value){
            this.val = value;
        }
    }
}