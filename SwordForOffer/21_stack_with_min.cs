using System;
using System.Collections.Generic;

namespace ConsoleApplication {
    /// <summary>
    /// 包含min函数的stack实现
    /// 
    /// 通过一个 min 辅助栈来完成
    /// </summary>
    public class StackWithMin : ITemplate
    {

        public void print()
        {
            void getmin(Delegate func, params object[] args){
                func.DynamicInvoke(args);
                System.Console.WriteLine($"min: {Min()}, stack: {string.Join(' ', this.m_data)}");
            }

            getmin(new Action<int>(Push), 4);
            getmin(new Action<int>(Push), 3);
            getmin(new Action<int>(Push), 5);
            getmin(new Action<int>(Push), 1);
            getmin(new Func<int>(Pop));
            getmin(new Func<int>(Pop));
            getmin(new Action<int>(Push), 0);
        }

        private Stack<int> m_data = new Stack<int>();
        private Stack<int> m_min = new Stack<int>();


        public void Push(int val){
            m_data.Push(val);
            if(m_min.Count <= 0 || val < m_min.Peek()){
                m_min.Push(val);
            }else{
                m_min.Push(m_min.Peek());
            }
        }

        public int Pop(){
            m_min.Pop();
            return m_data.Pop();
        }

        public int Min() {
            return m_min.Peek();
        }
    }
}