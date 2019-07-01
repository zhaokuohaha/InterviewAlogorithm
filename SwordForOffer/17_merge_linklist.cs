// 合并两个已经排好序的链表

using System;

namespace ConsoleApplication{
    public class MergeLinklist : ITemplate
    {
        public void print()
        {
            Merge(
                new ListNode(new []{1,4,6,8,10}),
                new ListNode(new []{2,3,5,7,8,9,11,12,13,15})).Print();
        }

        private ListNode Merge(ListNode h1, ListNode h2){
            if(h1 == null || h2 == null)
                return h1 ?? h2;

            var head = h1.val < h2.val ? h1 : h2;
            var cur = new ListNode(-1);

            while(h1 != null && h2 != null){
                if(h1.val < h2.val){
                    cur.next = h1;
                    h1 = h1.next;
                }else{
                    cur.next = h2;
                    h2 = h2.next;
                }
                cur = cur.next;
            }

            if(h1 != null) cur.next = h1;
            if(h2 != null)  cur.next = h2;

            return head;
            // 最终生成的链表其实是: -1 -> head -> ... -> cur -> (h1 | h2)
        }
    }
}