using System;

namespace ConsoleApplication
{
    public class FirstCommonNode : ITemplate
    {
        public void print()
        {
            // 1 -> 2 -> 3 -> 6  -> 7
            //      4 -> 5 ↗
            var p1 = new ListNode(1);
            var p2 = new ListNode(2);
            var p3 = new ListNode(3);
            var p4 = new ListNode(4);
            var p5 = new ListNode(5);
            var p6 = new ListNode(6);
            var p7 = new ListNode(7);

            p1.next = p2; p2.next = p3; p3.next = p6; p6.next = p7;
            p4.next = p5; p5.next = p6;
            System.Console.WriteLine(FindFirstNode(p1, p4).val);
        }
        // 思路: 双指针法.
        // 因为相遇后的长度一样, 所以只要保证在相遇前同样长度的地方同时起步, 两颗指针就能相遇
        // 实现的办法就是先让长链表的指针先走 delta 步, 然后齐步走  delta 为两条链表的差值
        // 求链表长度的方法整合到 listnode 类中了.  时间复杂度O(m+n)
        private ListNode FindFirstNode(ListNode p1, ListNode p2)
        {
            int c1 = p1.NodeCount, c2 = p2.NodeCount;
            int delta = Math.Abs(c1 - c2);

            var pLong = c1 > c2 ? p1 : p2;
            var pShor = pLong == p1 ? p2 : p1;

            // 长链先走 delta 步
            while (delta-- > 0)
            {
                pLong = pLong.next;
            }
            // 然后齐走, 一定在链表会合的地方相遇
            while (pLong != pShor && pLong != null && pShor != null)
            {
                pLong = pLong.next;
                pShor = pShor.next;
            }

            return pLong;
        }
    }
}