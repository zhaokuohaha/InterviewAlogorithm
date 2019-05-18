/// <summary>
/// 迪杰斯特拉，查找全图最小路径算法
/// 原理: 最优子路径存在。假设从S→E存在一条最短路径SE，且该路径经过点A，那么可以确定SA子路径一定是S→A的最短路径。证明：反证法。如果子路径SA不是最短的，那么就必然存在一条更短的'SA，从而SE路径也就不是最短，与原假设矛盾。
/// </summary>
using System;

namespace ConsoleApplication
{
    public class DijkstraClass
    {
        //int max = int.MaxValue; 由于所有数据都是int, 如果这里用int.MaxValue, 底下 dist[u] + g[u,v]就有可能成为负数, 导致结果错误
        int max = 99999;
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
            int[] dist = Dijkstra(3,g);
            foreach (int item in dist)
            {
                Console.Write(item+" ");
            }

            //Dijkstra(0,g) : 0 6 3 6 7 9 11
            //Dijkstra(3,g) : 6 5 3 0 2 3 6
            //Dijkstra(6,g) : 11 11 8 6 4 3 0
        }

        /// <summary>
        /// 获取出发节点到每个节点的最短路径
        /// </summary>
        /// <param name="root">出发节点</param>
        /// <param name="g">图</param>
        /// <returns></returns>
        public int[] Dijkstra(int root, int[,] g){
            int height = g.GetLength(0);
            int width = g.GetLength(1);         //二维数组的宽和高， 理论上应该是相等的， 这里为了演示下C#取值的方法
            int[] dist = new int[height];       //存储最短路径的一维数组
            bool[] vis = new bool[height];      //c存储已经被访问, 也就是确定了最短距离的点
            //初始化
            for(int i=0; i<height; i++)
                dist[i] = g[root,i];
            dist[root] = 0;
            vis[root] = true;
            for(int i=0; i<height; i++){
                //大循环表示需要刷新height轮, 每轮能够确定一个点的最小路径, 里面小循环一个找最小值, 一个更新路径
                //min: 每次遍历过程的最小距离, u: 取得最小距离的点
                //每次循环都需要把min初始化, 如果min放在总循环外边, 比如当第一次遍历之后min的值变得很小,  后面min就不会更新导致会出错, u倒不一定, min更新后u自然更新, 放在一起只是为了好理解
                int u=root;
                int min = max;
                for(int j=0; j<dist.Length; j++){
                    if(!vis[j] && dist[j] < min){
                        min = dist[j];
                        u=j;
                    }
                }
                vis[u] = true;

                for(int v=0; v<width; v++){
                    dist[v] = Math.Min(dist[v], dist[u]+g[u,v]);
                }
            }
            return dist;    
        }
    }
}