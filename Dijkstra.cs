using System;

namespace ConsoleApplication
{
    public class DijkstraClass
    {
        public void print(){
            /*
             /b—— d—— f
            a  \ / \ / \
             \ c —— e —— g      
            */
            //int max = int.MaxValue;
            int max = 9999;
            int[,] g = new int[,]{
                {0,7,3,max,max,max,max},
                {7,0,3,5,max,max,max},
                {3,3,0,3,4,max,max},
                {max,5,3,0,2,3,max},
                {max,max,4,2,0,5,4},
                {max,max,max,3,5,0,3},
                {max,max,max,max,4,3,0}
            };
            int[] dist = Dijkstra(0,g);
            foreach (int item in dist)
            {
                Console.Write(item+" ");
            }
            // for (int i = 0; i < g.GetLength(0); i++)
            // {
            //     for(int j=0; j<g.GetLength(1); j++){
            //         Console.Write(g[i,j]+" ");
            //     }
            //     Console.WriteLine();
            // }
        }

        public int[] Dijkstra(int root, int[,] g){
            int height = g.GetLength(0);
            int width = g.GetLength(1);
            int[] dist = new int[height];
            bool[] vis = new bool[height];
            for(int i=0; i<height; i++)
                dist[i] = 9999;
            dist[0] = 0;
            vis[0] = true;
            int min = 9999;
            int min_index = 0;
            for(int u=0; u<height; u++){
                for(int v=0; v<width; v++){
                    if(u==v || vis[v]) continue;
                    dist[v] = Math.Min(dist[v], dist[u]+g[u,v]);
                    if(dist[v] < min){
                        min = dist[v];
                        min_index = v;
                    }
                }
                vis[min_index] = true;
            }
            return dist;    
        }
    }
}