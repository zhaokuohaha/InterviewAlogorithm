// 删除链表当前节点， 要求时间复杂度 O(1)
// 思路： 将下一个节点的内容复制到当前节点， 并删除下一节点， 避免因为节点查找而造成时间复杂度为O(n)的情况

using System;

namespace ConsoleApplication{
    public class DeleteLinkListNode : ITemplate
    {
        public void print()
        {
            var head = new ListNode(1);
            var node = new ListNode(-1);
            var tail = new ListNode(new[]{5,6,7});
            head.next = new ListNode(2);
            head.next.next = node;
            node.next = tail;

            head.Print();
            DeleteInternal(head, node);
            head.Print();
        }

        /// <summary>
        /// 删除链表中的一个节点， 这里有个前提， 是要保证节点在链表中
        /// </summary>
        /// <param name="head"></param>
        /// <param name="node"></param>
        /// <returns></returns>
        private ListNode DeleteInternal (ListNode head, ListNode node){
            if(node.next == null){
                node = null; 
            }else{
                node.val = node.next.val;
                node.next = node.next.next;
            }
            return head;
        }
    }
}
