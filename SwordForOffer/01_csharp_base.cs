using System;

namespace ConsoleApplication
{
    public class ScharpBase : ITemplate
    {
        public void print()
        {
            B b = new B();

            /*
             在调用B的代码之前先执行B的静态构造函数 static B ()
                1. 先初始化静态变量 --> output a1
                2. 执行静态构造函数内的语句 --> output a3
             调用浦东构造函数 B ()
                1. 先初始化成员变量 --> output a2
                2. 执行构造函数内的语句 --> output a4
             */
        }
    }
    class A {
        public A (string text){
            Console.WriteLine(text);
        }
    }

    class B {
        static A a1 = new A("a1");
        A a2 = new A("a2");
        static B () {
            new A("a3");
        }


        public B () {
            new A("a4");
        }
    }
}

