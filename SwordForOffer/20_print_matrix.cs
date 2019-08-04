using System;

namespace ConsoleApplication {
    /// <summary>
    /// 顺时针打印矩阵
    /// </summary>
    public class PrintMatrixClockwisely : ITemplate
    {
        public void print()
        {
            var m = new int[,]{
                {1,2,3,4},
                {5,6,7,8},
                {9,10,11,12},
                {13,14,15,16}
            };
            var res = PrintMatrix(m);
            System.Console.WriteLine(string.Join(", ", res));
        }

        private int[] PrintMatrix(int[,] matix){
            var h = matix.GetLength(0);
            var w = matix.GetLength(1);
            var visit = new bool[h, w]; // 标记数组

            var direct = new [,]{{0,1}, {1,0}, {0,-1}, {-1,0}};   // 指针移动的方向
            int x = 0, y = 0, dirIndex = 0; // x, y 当前位置， dirIndex：当前移动方向选择
            
            var index = 0;
            var res = new int[h*w];
            while(index < h * w){
                res[index] = matix[x,y];
                visit[x, y] = true;

                // 如果按照当前方向继续遍历， 下一个元素无效， 则转变方向， 根据direct数据循环取方向
                var nextX = x + direct[dirIndex, 0];
                var nextY = y + direct[dirIndex, 1];
                if(!isAvaliable(visit, nextX, nextY)){
                    dirIndex = (dirIndex + 1) % 4;
                }

                index ++;
                x += direct[dirIndex, 0];
                y += direct[dirIndex, 1];
            }
            return res;
        }

        private bool isAvaliable(bool[,] visit, int x, int y)
        {
            return x >= 0 && x < visit.GetLength(0)
                && y >= 0 && y < visit.GetLength(1)
                && !visit[x, y];
        }
    }
}