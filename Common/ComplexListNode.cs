using System.Collections.Generic;

namespace ConsoleApplication{
    /// <summary>
    /// 复杂链表， 除next节点外还有一个可以任意指向任意其他节点的节点sibling
    /// </summary>
    public class ComplexListNode{
        public int val { get; set; }
        public ComplexListNode next { get; set; }
        public ComplexListNode sibling { get; set;}

        public ComplexListNode(int value){val = value;}

        public ComplexListNode(IEnumerable<int> list){
            var node = new ComplexListNode(-1){next = this};
            foreach(var item in list){
                node.next = new ComplexListNode(item);
                node = node.next;
            }
        }

        public override string ToString() {
            return this?.val.ToString() ?? "null";
        }

        public void print(){
            if(this == null){
                System.Console.WriteLine("null");
                return;
            }

            var node = this;
            while(node != null){
                System.Console.WriteLine($"({node.next}, {node.sibling})");
                node = node.next;
            }
        }
    }
}