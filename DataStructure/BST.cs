/// <summary>
/// 二叉查找树
/// 参考: http://www.cnblogs.com/gaochundong/p/binary_search_tree.html
/// </summary>
using System;

namespace ConsoleApplication{
    /// <summary>
    /// Binary Searc Tree 二叉查找树
    /// 对于任一节点， 其左子树的每个节点的值都小于它， 右子树的每个节点值都大于它
    /// </summary>
    public class BST{
        public TreeNode root;
        public BST(){
            root = null;
        }

        public void print(){
            Insert(3);
            Insert(1);
            Insert(2);
            Insert(4);
            Insert(5);
            
            Traversal();

            Insert(8);
            Remove(4);
            Traversal();
        }

        /// <summary>
        /// 查找节点
        /// </summary>
        /// <param name="val">节点值</param>
        /// <returns></returns>
        public TreeNode Find(int val){
            var cur = root;
            while(cur != null){
                if(cur.val == val)
                    return cur;
                if(cur.val > val)
                    cur = cur.left;
                else
                    cur = cur.right;
            }
            return null;
        }

        /// <summary>
        /// 中序遍历， 从小到大输出
        /// </summary>
        /// <param name="node"></param>
        public void Traversal(){
            TraversalInternal(root);
        }
        private void TraversalInternal(TreeNode node){
            if(node == null) return;
            TraversalInternal(node.left);
            Console.WriteLine("-->" + node.val);
            TraversalInternal(node.right);
        }
        
        /// <summary>
        /// 插入节点， 用两个游标记录即将插入的节点位置, 时间复杂度， O(logN)
        /// </summary>
        /// <param name="i">节点值</param>
        public void Insert(int i){
            if(root==null) root=new TreeNode(i);
            else{
                TreeNode cur = root;
                TreeNode pre = cur;
                while(cur != null ){
                    pre = cur;
                    if(cur.val < i){
                        cur = cur.right;
                    }else{
                        cur = cur.left;
                    }
                }

                if(i < pre.val)
                    pre.left = new TreeNode(i);
                else
                    pre.right = new TreeNode(i);
            }
        }

        /// <summary>
        ///  删除节点
        /// </summary>
        /// <param name="val">节点值</param>
        public void Remove(int val){
            var node = Find(val);
            if(node == null){
                Console.WriteLine("找不到节点");
                return;
            }

            // case 1 : 叶子节点， 直接删除
            if(node.left == null && node.right == null){
                node = null;
            }

            // case 2: 没有右节点， 直接用左节点代替当前节点
            else if(node.right == null){
                // TODO zhaokuohaha 20190518 这种， 是不是能直接用节点赋值？ 未测试
                node.val = node.left.val;
                node.left = node.left.left;
                node.right = node.left.right;
            }

            // case 3: 右节点没有左节点， 直接用右节点替换当前节点
            else if(node.right.left == null){
                node.val = node.right.val;
                node.left = node.right.left;
                node.right = node.right.right;
            }

            // case 4: 右节点有左节点， 用右子树最小左节点替换当前节点
            else {
                var min = node.right.left;
                while(min != null){
                    min = min.left;
                }
                node.val = min.val;
                if(min.right != null){
                    min.val = min.right.val;
                    min.right = null;
                }else{
                    min = null;
                }
            }
            Console.WriteLine("删除成功");
        }
    }
}