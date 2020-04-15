using System;

namespace ConsoleApplication{
    public class CloneComplexNode : ITemplate
    {
        public void print()
        {
            var node = new ComplexListNode(new []{1, 2, 3, 4,5});
            node.sibling = node.next.next;
            node.next.sibling = node.next.next.next.next;
            node.next.next.next.sibling = node.next;

            node.print();


            var cpNode = CloneNodes(node);
            node.print();
            cpNode.print();
            
        }

        private ComplexListNode CloneNodes(ComplexListNode node){
            CopyNodes(node);
            ConnectSibilingNodes(node);
            return SliceNodes(node);
        }

        private void CopyNodes(ComplexListNode node)
        {
            var head = node;
            while(node != null){
                var cpNode = new ComplexListNode(node.val);
                cpNode.next = node.next;
                node.next = cpNode;
                node = cpNode.next;
            }
        }

        private void ConnectSibilingNodes(ComplexListNode node)
        {
            while(node.next != null && node.next.next != null){
                if(node.sibling != null)
                    node.next.sibling = node.sibling.next;
                node = node.next.next;
            }
        }

        private ComplexListNode SliceNodes(ComplexListNode node)
        {
            var head = node;
            var cpNode = node.next;
            var cpHead = cpNode;
            while(node != null && cpNode != null){
                node.next = cpNode.next;
                cpNode.next = cpNode.next?.next;

                node = node.next;
                cpNode = cpNode.next;
            }
            
            node = head;
            return cpHead;
        }
    }
}