// 用两个栈实现队列

using System;
using System.Collections.Generic;

namespace ConsoleApplication{
    public class QueueUseStack : ITemplate
    {
        public void print()
        {
            var s = new QueueUseStackImplement<int>();
            s.InQueue(1);
            s.InQueue(2);
            System.Console.WriteLine(s.DeQueue());
            s.InQueue(3);
            s.InQueue(4);
            s.InQueue(5);
            System.Console.WriteLine(s.DeQueue());
            s.InQueue(6);
            while(s.Count > 0)
                System.Console.WriteLine(s.DeQueue());
        }
    }

    public class QueueUseStackImplement<T>{
        private Stack<T> stack1 = new Stack<T>();
        private Stack<T> stack2 = new Stack<T>();
        public int Count => stack1.Count + stack2.Count;
        
        public void InQueue(T val){
            stack1.Push(val);
        }

        public T DeQueue() {
            if(stack2.Count > 0){
                return stack2.Pop();
            }

            while(stack1.Count > 0){
                stack2.Push(stack1.Pop());
            }
            return stack2.Pop();
        }
    }
}