// 给定一个链表， 找出链表的倒数第k个节点， 返回节点的值
// 注意本节要考虑代码的鲁棒性， 在本例中如： 链表为 null, k > 总长， k = 0 等

using System;

namespace ConsoleApplication {
    public class KthToTail : ITemplate
    {
        public void print()
        {
            var head = new ListNode(new []{1,2,3,4,5,6,7,8,9});
            System.Console.WriteLine(Find(head, 0)?.val.ToString() ?? "参数错误, 找不到数据");
            System.Console.WriteLine(Find(head, 1)?.val.ToString() ?? "参数错误, 找不到数据");
            System.Console.WriteLine(Find(head, 5)?.val.ToString() ?? "参数错误, 找不到数据");
            System.Console.WriteLine(Find(head, 9)?.val.ToString() ?? "参数错误, 找不到数据");
            System.Console.WriteLine(Find(head, 20)?.val.ToString() ?? "参数错误, 找不到数据");
        }

        /// <summary>
        /// 找出head中倒数第k个节点, 实现思路: 双指针
        /// </summary>
        /// <param name="head"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        private ListNode Find(ListNode head, uint k){
            if(head == null || k == 0) return null;
            var left = head;
            var right = head;

            while(k > 0 && right != null){
                right = right.next;
                k--;
            }

            // k > 链表长度
            if(right == null && k > 0) return null;

            while(right != null){
                right = right.next;
                left = left.next;
            }

            return left;
        }
    }
}