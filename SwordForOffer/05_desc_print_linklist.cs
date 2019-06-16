// 倒叙输出一条链表的值, 假设不能改变链表本身

using System;
using System.Collections.Generic;

namespace ConsoleApplication {
    public class DescPrintLinklist : ITemplate
    {
        public void print()
        {
            var vals = new [] {1,2,3,4,5,6,7,8};
            var head = new ListNode(0);
            var p = head;
            foreach(var val in vals){
                p.next = new ListNode(val);
                p = p.next;
            }

            PrintWithStack(head); System.Console.WriteLine();
            PrintWithRecursion(head); System.Console.WriteLine();
        }

        // 思路一， 用栈（数组）存储， 空间复杂度 O(n)
        void PrintWithStack (ListNode head){
            Stack<int> vals = new Stack<int>();
            var p = head;
            while(p != null){
                vals.Push(p.val);
                p = p.next;
            }

            while(vals.TryPop(out var val)){
                System.Console.Write(val);
            }
        }


        // 思路二， 使用递归, 空间复杂度 O(1) --> 运行算法时所消耗的内存空间不算在算法的复杂度里面
        // 事实上这个方法可能会用掉很多内存甚至爆栈
        void PrintWithRecursion(ListNode head){
            if(head == null)
                return;
            PrintWithRecursion(head.next);
            System.Console.Write(head.val);
        }

    }
}


