using System;

namespace ConsoleApplication
{
    public class FloydClass
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
            Floyd(g);
            for(int i=0; i<g.GetLength(0); i++){
                for(int j=0; j<g.GetLength(1); j++){
                    Console.Write(g[i,j]+"\t");
                }
                Console.WriteLine();
            }
        }
        //   g(i,j)：表示从i到j中途不经过索引比k大的点的最短路径
        public void Floyd(int[,] g){
            int len = g.GetLength(0);
            for(int k=0; k<len; k++){
                for(int i=0; i<len; i++){
                    for(int j=0; j<len; j++){
                        g[i,j] = Math.Min(g[i,j], g[i,k]+g[k,j]);
                    }
                }
            }
        }
    }
}