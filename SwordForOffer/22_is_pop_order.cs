using System;
using System.Collections.Generic;

namespace ConsoleApplication {
    /// <summary>
    /// 根据入栈顺序判断出栈顺序是否合法。
    /// 思路: 用一个栈来模拟实现， 每次入栈后开始循环判断出栈，最后如果栈为空说明顺序合法
    /// </summary>
    public class IsPopOrder : ITemplate
    {
        public void print()
        {
            var push = new [] {1,2,3,4,5};
            System.Console.WriteLine(CheckPopOrder(push, new int[]{4,5,3,2,1}));
            System.Console.WriteLine(CheckPopOrder(push, new int[]{5,4,3,2,1}));
            System.Console.WriteLine(CheckPopOrder(push, new int[]{4,3,5,1,2}));
        }

        private bool CheckPopOrder(int[] push, int[] pop){
            if(push == null || pop == null || push.Length == 0 || push.Length != pop.Length)
                return false;
            var stack = new Stack<int>();
            var popIndex = 0;
            for(var i = 0; i < push.Length; i++){
                stack.Push(push[i]);
                while(stack.Count > 0 && stack.Peek() == pop[popIndex]){
                    stack.Pop();
                    popIndex ++;
                }
            }
            return stack.Count == 0;
        }
    }
}