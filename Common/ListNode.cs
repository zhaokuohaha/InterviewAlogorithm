using System;
using System.Collections.Generic;

namespace ConsoleApplication
{
    /// <summary>
    /// 链表节点 
    /// </summary>
    public class ListNode
    {
        public int val { get; set; }
        public ListNode next { get; set; }
        public ListNode(int value)
        {
            this.val = value;
        }

        public ListNode(int[] arr)
        {
            if (arr.Length < 1) return;
            this.val = arr[0];
            if (arr.Length < 2) return;
            var p = this;
            for (var i = 1; i < arr.Length; i++)
            {
                p.next = new ListNode(arr[i]);
                p = p.next;
            }
        }

        public void Print()
        {
            var p = this;
            while (p.next != null)
            {
                System.Console.Write($"{p.val} -> ");
                p = p.next;
            }
            System.Console.WriteLine(p.val);
        }

        public int NodeCount => GetNodeCount();
        private int GetNodeCount()
        {
            var p = this;
            var count = 0;
            while (p != null)
            {
                count++;
                p = p.next;
            }
            return count;
        }
    }
}