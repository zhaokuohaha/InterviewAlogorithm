// 反转链表

using System;

namespace ConsoleApplication{
    public class ReverseLinkList : ITemplate
    {
        public void print()
        {
            var nodes = new []{
                new ListNode(1),
                new ListNode(new []{1,2}),
                new ListNode(new []{1,2,3}),
                new ListNode(new []{1,3,4,5,6,7,8})
            };
            foreach(var head in nodes){
                head?.Print();
                Reverse(head)?.Print();
            }
        }

        /// <summary>
        /// 反转链表, 使用三个指针逐一操作就可以
        /// </summary>
        /// <param name="head"></param>
        /// <returns></returns>
        private ListNode Reverse(ListNode head){
            if(head == null || head.next == null)
                return head;

            ListNode cur = null;
            while(head != null){
                var next = head.next;
                head.next = cur;
                cur = head;
                head = next;
            }
            return cur;
        }
    }
}