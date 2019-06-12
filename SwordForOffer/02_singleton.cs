// 实现 singleton 模式

using System;

namespace ConsoleApplication {

    public sealed class SingletonDemo1 : ITemplate
    {
        public  int val { get; set; }
        static SingletonDemo1 instance = new SingletonDemo1();
        private SingletonDemo1 (){}
        public static SingletonDemo1 Instance => instance;
        public void print()
        {
            System.Console.WriteLine(val);
        }
    }
    public sealed class SingletonDemo2 : ITemplate {
        public int val { get; set; }
        SingletonDemo2 () {}
        public static SingletonDemo2 Instance => Nested.instance;

        class Nested{
            internal static readonly SingletonDemo2 instance = new SingletonDemo2();
        }

        public void print()
        {
            Console.WriteLine(this.val);
        }
    }
}