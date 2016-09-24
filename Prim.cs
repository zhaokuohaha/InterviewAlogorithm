using System;

namespace ConsoleApplication
{
    public class PrimClass
    {
        int max = 9999;
        public void print(){
             /*
             /b—— d—— f
            a  \ / \ / \
             \ c —— e —— g      
            */
            //int max = int.MaxValue;
            //图源: http://img.blog.csdn.net/20130831184137437
            int[,] g = new int[,]{
                {0,7,3,max,max,max,max},
                {7,0,3,5,max,max,max},
                {3,3,0,3,4,max,max},
                {max,5,3,0,2,3,max},
                {max,max,4,2,0,5,4},
                {max,max,max,3,5,0,3},
                {max,max,max,max,4,3,0}
            };
            int[] res = Prim(g);
            foreach (int item in res)
            {
                Console.Write(item + " ");
            }
        }

        public int[] Prim(int[,] g){
            int len = g.GetLength(0);
            int[] tree = new int[len];      //现在主要还不明白这个tree表示的意思, 执行的结果是最小生成树的边
            bool[] vis = new bool[len];     //标记已经访问过的点
            for(int i=1; i<len; i++)//初始化
                tree[i] = g[0,i];
            int pos = 0;                    //每一轮确定的点
            vis[0] = true;
            int result = 0;                 //树总路径长度

            for(int i=1; i<len; i++){//第一个点在刚刚的时候已经初始化过了, 所以这里只需要执行n-1轮更新
                int min = max;
                // 确定最小的边, 加入 到最小生成树中(标记为vis)
                for(int j=0; j<len; j++){
                    if(!vis[j] && tree[j] < min){
                        min = tree[j];
                        pos = j;
                    }
                }
                
                //Console.WriteLine(pos+"---"+min);
                result += min;
                vis[pos] = true;

                //从已访问点更新未访问点的最小边, tree保存的是我当前点所连接的未访问的点的最小边的边长
                for(int j=0; j<len; j++){
                    if(!vis[j] && tree[j] > g[pos,j]){
                        tree[j] = g[pos,j];
                    }
                }
            }
            Console.WriteLine("result: " + result);
            return tree; //其实这个时候返回tree数组已经没有什么意义了, 如果要返回树的结构的话还需要另一个类来保存g[i,pos]
        }
    }
}