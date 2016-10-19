using System;

namespace ConsoleApplication
{
    /// <summary>
    /// 反转链表
    /// </summary>
    public class ReverseLinkListClass  
    {
        public void print(){
            ListNode l1,l2,l3,l4,l5;
            l1 = new ListNode(1);
            l2 = new ListNode(2);
            l3 = new ListNode(3);
            l4 = new ListNode(4);
            l5 = new ListNode(5);
            l1.next = l2;l2.next=l3;l3.next=l4;l4.next=l5;
            ListNode l = ReverseLinkList(l1);
            while(l != null){
                Console.Write(l.val+" ");
                l = l.next;
            }
        }

        public ListNode ReverseLinkList(ListNode pHead){
            ListNode pre = null, cur = pHead, nex = null;
            while(cur != null){
                nex = cur.next;
                cur.next = pre;
                pre = cur;
                cur = nex;
            }
            return pre;
        }
    }
}